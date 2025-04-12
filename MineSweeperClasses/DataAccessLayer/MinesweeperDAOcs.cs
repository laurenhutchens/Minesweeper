/*
 * Milestone 2: Interactive Playable Version
 * Lauren Hutchens and Arie Gerard
 * Professor Hughes
 * CST-250
 * 2/9/2005
 */

using MineSweeperClasses.BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperClasses.DataAccessLayer
{

    //this class is intended to handle data access, specifically saving and loading game states (not yet implemented). 
    internal class MinesweeperDAOcs
    {
        //Include logic for game saving and logic. 
        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            // Open a Save File Dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Leaderboard";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    var gameData = GetGameDataToSave();
                    MineSweeperClasses.DataAccessLayer.MinesweeperDAOcs.tsmSave(gameData, filePath);
                }
            }
        }


        private void TsmLoadClickEH(object sender, EventArgs e)
        {
            // Open an Open File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Load Leaderboard";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    var loadedData = MineSweeperClasses.DataAccessLayer.MinesweeperDAOcs.tsmLoad<List<GameStat>>(filePath);

                    if (loadedData != null)
                    {
                        statList = loadedData;
                        bindingSource.DataSource = statList;
                        bindingSource.ResetBindings(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load leaderboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
