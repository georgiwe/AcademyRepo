using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class CardWars2point0
{
    static void Main(string[] args)
    {
        int numberOfGames = int.Parse(Console.ReadLine());

        BigInteger player1score = 0;
        BigInteger player2score = 0;

        byte player1gamesWon = 0;
        byte player2gamesWon = 0;

        bool player1hasDrawnX = false;
        bool player2hasDrawnX = false;
        bool gameOver = false;

        for (int i = 0; (i < numberOfGames) && (gameOver == false); i++)
        {
            player1hasDrawnX = false;
            player2hasDrawnX = false;

            int tempPlayer1score = 0;
            int tempPlayer2score = 0;
            byte player1zCardCount = 0;
            byte player2zCardCount = 0;

            // calculate player 1 score 
            for (int j = 0; j < 3; j++)
            {
                string input = Console.ReadLine();
                switch(input)
                {
                    case "A": tempPlayer1score += 1; break;
                    case "J": tempPlayer1score += 11; break;
                    case "Q": tempPlayer1score += 12; break;
                    case "K": tempPlayer1score += 13; break;
                    case "Z": player1zCardCount++; break;
                    case "Y": player1score -= 200; break;
                    case "X": player1hasDrawnX = true; break;
                    default: tempPlayer1score += 6 + (6 - 
                        int.Parse(input)); break;
                }
            }

            // calculate player 2 score
            for (int j = 0; j < 3; j++)
            {
                string input = Console.ReadLine();
                switch (input)
                {              
                    case "A": tempPlayer2score += 1; break;
                    case "J": tempPlayer2score += 11; break;
                    case "Q": tempPlayer2score += 12; break;
                    case "K": tempPlayer2score += 13; break;
                    case "Z": player2zCardCount++; break;
                    case "Y": player2score -= 200; break;
                    case "X": player2hasDrawnX = true; break;
                    default: tempPlayer2score += 6 + (6 - 
                        int.Parse(input)); break;
                }
            }

            if (tempPlayer1score > tempPlayer2score)
            { player1score += tempPlayer1score; player1gamesWon++;}
            else if (tempPlayer1score < tempPlayer2score)
            { player2score += tempPlayer2score; player2gamesWon++;}
            else if (tempPlayer1score == tempPlayer2score) { }

            if ((player1hasDrawnX == true) && player2hasDrawnX == false)
                gameOver = true;
            else if ((player2hasDrawnX == true) && (player1hasDrawnX == false))
                gameOver = true;
            else if ((player1hasDrawnX) && (player2hasDrawnX))
            {
                player1score += 50; player2score += 50;
                player1hasDrawnX = false; player2hasDrawnX = false;
            }

            if (player1zCardCount > 0) { player1score = player1score * (int)(Math.Pow(2, player1zCardCount)); }
            if (player2zCardCount > 0) { player2score = player2score * (int)(Math.Pow(2, player2zCardCount)); }

        }

        if (player1hasDrawnX == true) 
            Console.WriteLine("X card drawn! Player one wins the match!");
        else if (player2hasDrawnX == true)
            Console.WriteLine("X card drawn! Player two wins the match!");
        else if (player1score > player2score)
        { Console.WriteLine("First player wins!\nScore: {0}\nGames won: {1}", player1score, player1gamesWon); }
        else if (player2score > player1score)
        { Console.WriteLine("Second player wins!\nScore: {0}\nGames won: {1}", player2score, player2gamesWon); }
        else if (player1score == player2score)
        { Console.WriteLine("It's a tie!\nScore: {0}", player1score); }
    }
}
