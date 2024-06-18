namespace boxoio;
using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        
        if(args.Length>0) {

        switch (args[0]) {
            case "-help":
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.Write("\nboxo");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("IO CLI \n");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("\n    [debox] - params [filename] de-boxo-ifies a file. \n    [read] - params [filename]: reads a file. \n    [write] - params [filename, text]: appends a line of text to a file \n    [create] - params [filename]: creates a file \n    [del] - params [filename]: deletes a file \n    [copy] - params [filename, new_filename]: copies the contents of a file to another file \n \n type. \n");
                break;
            case "--help":
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.Write("\nboxo");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("IO CLI \n");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("\n    [debox] - params [filename] de-boxo-ifies a file. \n    [read] - params [filename]: reads a file. \n    [write] - params [filename, text]: appends a line of text to a file \n    [create] - params [filename]: creates a file \n    [del] - params [filename]: deletes a file \n    [copy] - params [filename, new_filename]: copies the contents of a file to another file \n \n type. \n");
                break;

            case "read":
                if(args.Length>1) {
                    
                    if(!File.Exists(args[1])) {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("file doesn't exist :(");
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    else {
                        StreamReader sr = new StreamReader(args[1]);
                        Console.Write(sr.ReadToEnd());
                    }
                }
                else {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("no file provided :(");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                
                break;

            case "write":
                if(args.Length>1) {
                    if(!File.Exists(args[1])) {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("file doesn't exist :(");
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    else {

                        StreamWriter sw = new StreamWriter(args[1], append:true);
                        
                        sw.WriteLine(args[2]); //this should append now!

                        sw.Dispose();
                        sw.Close();
                    }

                }
                else {
                Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("no file provided :(");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                break;

            case "box":
                if(args.Length>1) {
                    if(!File.Exists(args[1])) {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("file doesn't exist :(");
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    else {
                        StreamReader sr = new StreamReader(args[1]);
                        string line = "";
                        string file = "";
                        while ((line = sr.ReadLine()) != null) {
                            if (line != "") {
                                file+=Vigenere.Encode(line, "boxo") + '\n';
                            }
                            else {
                                file+='\n';
                            }
                        }

                        sr.Close();

                        StreamWriter sw = new StreamWriter(args[1]);
                        sw.Write(file);

                        sw.Dispose();
                        sw.Close();
                    }
                }
                else {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("no file provided :(");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                break;

            case "debox":
                if(args.Length>1) {
                    if(!File.Exists(args[1])) {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("file doesn't exist :(");
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    else {
                        StreamReader sr = new StreamReader(args[1]);
                        string line = "";
                        string file = "";
                        while ((line = sr.ReadLine()) != null) {
                            if (line != "") {
                                file+=Vigenere.Decode(line, "boxo") + '\n';
                            }
                            else {
                                file+='\n';
                            }
                        }
                        
                        sr.Close();

                        StreamWriter sw = new StreamWriter(args[1]);
                        sw.Write(file);

                        sw.Dispose();
                        sw.Close();
                    }
                }
                else {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("no file provided :(");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                break;

            
            
            case "boxoify":
                if(args.Length>1) {
                    
                    Console.WriteLine(Vigenere.Encode(args[1],"boxo"));
                        
                    
                }
                else {
                Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("no message :(");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                break;  

            
            case "":
                Console.Write("\n boxoIO CLI \ntype -help for command info.");
                break;

            
        }}
        else{
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Console.Write("\nboxo");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("IO CLI \n");
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Write("\n hey you should\n  -help|--help for command info. \n  or a filename to boxo-ify a file \n");
        }
    }
}
