using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Compilateur.Exception;

namespace CompilateurTest._Masm
{
    public static class AssemblyRunner
    {
        /// <summary>
        /// Compile, link and run the assembly code generated
        /// The result is placed into an output file 
        /// </summary>
        /// <param name="mountFolder">The full path of the mount target folder</param>
        /// <param name="serie">Le nom du répertoire "série"</param>
        /// <param name="asmFile">__asm_code_File__.asm</param>
        /// <returns>The output file name</returns>
        public static string Start(string mountFolder, string serie, string asmFile, bool redirectAndClose=true)
        {

            var dosBoxPath = Path.Combine(mountFolder, @"_Masm\DosBox\DosBox.exe");
            var masmPath = Path.Combine("c:", @"_Masm\MP\masm.exe");
            masmPath = To8_3(masmPath);

            var linkPath = Path.Combine("c:", @"_Masm\MP\link.exe");
            linkPath = To8_3(linkPath);

            var bat1File = Path.Combine(mountFolder, @"generated\output\semantic\", serie);
            string generatedPath = Path.Combine(@"c:\generated\output\semantic\", serie);
            generatedPath = To8_3(generatedPath);

            FileInfo fi = new FileInfo(asmFile);
            asmFile = Path.Combine(generatedPath, asmFile);
            var objFile = Path.Combine(fi.Name.Replace(".asm",".obj"));
            var outputFile = Path.Combine(generatedPath, fi.Name.Replace(".asm",".txt"));
            var exeFile = Path.Combine(generatedPath, fi.Name.Replace(".asm",".exe"));
            var logFile = Path.Combine(fi.Name.Replace(".asm",".log"));
            var bat2File = Path.Combine(fi.Name.Replace(".asm",".bat"));
            asmFile = To8_3(asmFile);
            objFile = To8_3(objFile);
            outputFile = To8_3(outputFile);
            exeFile = To8_3(exeFile);
            logFile = To8_3(logFile);
            bat2File = To8_3(bat2File);
            bat1File = Path.Combine(bat1File, bat2File);

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = dosBoxPath,
                WorkingDirectory = mountFolder,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            // Prepare dosbox argument
            // Mount disk
            psi.Arguments = " -c \"mount c '" + mountFolder + "'\"";
            // Change disk
            psi.Arguments += " -c c: -c \"cd "+generatedPath+"\"";
            // Compile assembly
            List<string> bat = new List<string>();
            bat.Add("del " + exeFile); 
            bat.Add(masmPath + " " + asmFile + ",,,,,, > " + logFile);
            // Link obj file
            bat.Add(linkPath + " " + objFile + ",,,,, >> " + logFile);
            // Remove tmp files
            bat.Add("del *.crf"); bat.Add("del *.lst"); bat.Add("del *.obj"); bat.Add("del *.map");
            if( redirectAndClose)
            {
                // Run executable and redirect to file
                bat.Add(exeFile + " > " + outputFile );
                // Exit from DosBox
                bat.Add("exit -1");
            }
            else
            {
                // Run executable and redirect to file
                bat.Add("\"" + exeFile + "\"");
            }
            psi.Arguments += " -c \"" + bat2File + "\" ";
            File.WriteAllLines(bat1File, bat);

            Process p = new Process();
            p.StartInfo = psi;
            p.OutputDataReceived += (sender, args) => Console.Out.WriteLine(args.Data);
            p.ErrorDataReceived += (sender, args) => Console.Out.WriteLine(args.Data);
            p.Start();
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            p.WaitForExit();

            //Try to get error in the masm & link execution
            logFile = Path.Combine(mountFolder, @"generated\output\semantic\", serie, logFile);
            var log = File.ReadAllText(logFile);
            if (!log.Contains(" 0 Warning Errors") || !log.Contains(" 0 Severe  Errors"))
            {
                throw new MasmException("\n\nMASM or LINK Error in " + serie + "\\" + fi.Name + "\n\n" + log);
            }

            var v = fi.Name.Replace(".asm", ".txt");
            var v8 = To8_3(v);
            outputFile = Path.Combine(mountFolder, @"generated\output\semantic\", serie, v); 
            var file8 = Path.Combine(mountFolder, @"generated\output\semantic\", serie, v8); 
            File.Move(file8, outputFile, true);

            logFile = outputFile.Replace(".txt", ".log");
            file8 = file8.Replace(".txt", ".log");
            File.Move(file8, logFile, true);

            var output = File.ReadAllText(outputFile);
            return output;
        }

        public static string To8_3(string path)
        {
            String str = string.Empty;
            var tree = path.Split("\\");
            foreach (var leaf in tree)
            {
                var item = leaf;
                if (leaf.Contains("."))
                {
                    var index = leaf.LastIndexOf(".");
                    var name = leaf.Substring(0, index );
                    item = name;
                    var exten = leaf.Substring(index, leaf.Length - index );
                    if( name.Length>8)
                        item = name.Substring(0, 6) + "~1";
                    str += item + exten;
                }
                else
                {
                    if (leaf.Length > 8)
                        item = leaf.Substring(0, 6) + "~1";
                    str += item + "\\";
                }
            }
            return str.TrimEnd('\\');
        }
    }
}
