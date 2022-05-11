del c:\genera~1\output\semantic\instru~1\declar~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\instru~1\declar~1.asm,,,,,, > declar~1.log
c:\_Masm\MP\link.exe declar~1.obj,,,,, >> declar~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\instru~1\declar~1.exe > c:\genera~1\output\semantic\instru~1\declar~1.txt
exit -1
