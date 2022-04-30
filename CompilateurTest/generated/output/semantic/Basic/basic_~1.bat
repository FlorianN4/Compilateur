del c:\genera~1\output\semantic\Basic\basic_~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\Basic\basic_~1.asm,,,,,, > basic_~1.log
c:\_Masm\MP\link.exe basic_~1.obj,,,,, >> basic_~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\Basic\basic_~1.exe > c:\genera~1\output\semantic\Basic\basic_~1.txt
exit -1
