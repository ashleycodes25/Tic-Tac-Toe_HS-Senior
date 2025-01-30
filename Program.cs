using System;
using System.Text.RegularExpressions;
class Smith_Tic_Tac_Toe{
    static void Main(){
        string[,] board = {{" "," "," "}, {" "," "," "}, {" "," "," "}};
        string place = "";
        bool playing = true;
        bool guessing = true;
        int row = 0;
        int column = 0;
        printBoard(board);
        while(playing){
            guessing = true;
            while(guessing){
                Console.WriteLine("Player X, enter where you want to place your piece by giving the row and column divided by a comma. Ex: '1,3' (Row 1, Column 3)");
                place = Console.ReadLine();
                row = Int32.Parse(place[0]+"");
                column = Int32.Parse(place[2]+"");
                if(!checkValidInput(place, row, column)){
                    Console.WriteLine("Your input was invalid.");
                }
                else if(!checkValidPlace(board, row, column)){
                    Console.WriteLine("That space is full!");
                }
                else{
                    guessing = false;
                }
            }
            board = addToBoard(board, row, column, "X");
            Console.WriteLine("Player X has made their move! Here is the board now!");
            printBoard(board);
            if(checkWinner(board).Equals("Tie")){
                Console.WriteLine("Player X and the computer tied!");
                playing = false;
                break;
            }
            else if(checkWinner(board).Equals("X")){
                Console.WriteLine("Player X won!");
                playing = false;
                break;
            }
            else if(checkWinner(board).Equals("O")){
                Console.WriteLine("The computer won!");
                playing = false;
                break;
            }
            Console.WriteLine("The computer will now make a move!");
            board = computerMove(board);
            Console.WriteLine("The computer has made their move! Here is the board now!");
            printBoard(board);
            if(checkWinner(board).Equals("Tie")){
                Console.WriteLine("Player X and the computer tied!");
                playing = false;
            }
            else if(checkWinner(board).Equals("X")){
                Console.WriteLine("Player X won!");
                playing = false;
            }
            else if(checkWinner(board).Equals("O")){
                Console.WriteLine("The computer won!");
                playing = false;
            }
        }
    }
    static void printBoard(string[,] board){
        for(int i = 0; i < board.GetLength(0); i++){
            //Console.Write("[");
            for(int j = 0; j < board.GetLength(1); j++){
                /*
                if(board[i, j].Equals(" ")){
                    Console.Write("' '");
                }
                else{
                    Console.Write(" " + board[i, j] + " ");
                }
                if(j < (board.GetLength(1)-1)){
                    Console.Write(",");
                }
                */
                Console.Write(board[i, j]);
                if(j < board.GetLength(1)-1){
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            Console.WriteLine("-----");
            //Console.Write("]");
            //Console.WriteLine();
        }
    }
    static string checkWinner(string[,] board){
        bool x = false;
        bool o = false;
        bool tie = true;
        if(board[0,0].Equals("X") && board[0,1].Equals("X") && board[0,2].Equals("X")){
            x = true;
        }
        else if(board[1,0].Equals("X") && board[1,1].Equals("X") && board[1,2].Equals("X")){
            x = true;
        }
        else if(board[2,0].Equals("X") && board[2,1].Equals("X") && board[2,2].Equals("X")){
            x = true;
        }
        else if(board[0,0].Equals("X") && board[1,0].Equals("X") && board[2,0].Equals("X")){
            x = true;
        }
        else if(board[0,1].Equals("X") && board[1,1].Equals("X") && board[2,1].Equals("X")){
            x = true;
        }
        else if(board[0,2].Equals("X") && board[1,2].Equals("X") && board[2,2].Equals("X")){
            x = true;
        }
        else if(board[0,0].Equals("X") && board[1,1].Equals("X") && board[2,2].Equals("X")){
            x = true;
        }
        else if(board[0,2].Equals("X") && board[1,1].Equals("X") && board[2,0].Equals("X")){
            x = true;
        }
        else if(board[0,0].Equals("O") && board[0,1].Equals("O") && board[0,2].Equals("O")){
            o = true;
        }
        else if(board[1,0].Equals("O") && board[1,1].Equals("O") && board[1,2].Equals("O")){
            o = true;
        }
        else if(board[2,0].Equals("O") && board[2,1].Equals("O") && board[2,2].Equals("O")){
            o = true;
        }
        else if(board[0,0].Equals("O") && board[1,0].Equals("O") && board[2,0].Equals("O")){
            o = true;
        }
        else if(board[0,1].Equals("O") && board[1,1].Equals("O") && board[2,1].Equals("O")){
            o = true;
        }
        else if(board[0,2].Equals("O") && board[1,2].Equals("O") && board[2,2].Equals("O")){
            o = true;
        }
        else if(board[0,0].Equals("O") && board[1,1].Equals("O") && board[2,2].Equals("O")){
            o = true;
        }
        else if(board[0,2].Equals("O") && board[1,1].Equals("O") && board[2,0].Equals("O")){
            o = true;
        }
        for(int r = 0; r < 3; r++){
            for(int c = 0; c < 3; c++){
                if(board[r,c].Equals(" ")){
                    tie = false;
                }
            }
        }
        if(x && o){
            return "Tie";
        }
        else if(x){
            return "X";
        }
        else if(o){
            return "O";
        }
        else if(tie == true){
            return "Tie";
        }
        return "None";
    }
    static bool checkValidInput(string input, int row, int column){
        if(!(input[1] == ',')){
            return false;
        }
        if(row <= 0 || row > 3){
            return false;
        }
        if(column <= 0 || column > 3){
            return false;
        }
        return true;
    }
    static bool checkValidPlace(string[,] board, int row, int column){
        if(board[row-1, column-1].Equals(" ")){
            return true;
        }
        return false;
    }
    static string[,] addToBoard(string[,] board, int row, int column, string player){
        board[row-1,column-1] = player;
        return board;
    }
    static string[,] computerMove(string[,] board){
        Random rand = new Random();
        bool trying = true; 
        int row = 0;
        int column = 0;
        while(trying){
            row = rand.Next(1, 4);
            column = rand.Next(1, 4);
            if(checkValidPlace(board, row, column)){
                board[row-1, column-1] = "O";
                trying = false;
            }
        }
        return board;
    }
}