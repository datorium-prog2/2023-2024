using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class _21StickGame
    {
        public int StickCount { get; private set; }
        // Sākt spēli (bool) kurš sāk pirmais
        public bool IsPlayersTurn { get; private set; }
        public void StartGame(bool isPlayerStarting, int stickCount = 21)
        {
            IsPlayersTurn = isPlayerStarting;
            StickCount = stickCount;
        }

        public void PlayerMove(int pulledStickCount)
        {
            if (!IsPlayersTurn)
            {
                throw new Exception("Not a player's move");
            }

            if (pulledStickCount > 2 || pulledStickCount < 1)
            {
                throw new Exception("Invalid stick count");
            }

            StickCount -= pulledStickCount;
            IsPlayersTurn = false;
        }
        // PlayerMove (int) cik sērkociņus izvelk

        // ComputerMove

        // GetResults, kurš uzvar, kāds rezultāts etc.

        // Validate results (pārbaudīt, vai kāds jau neuzvar)
    }
}
