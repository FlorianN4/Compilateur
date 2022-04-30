del c:\genera~1\output\semantic\assign~1\assign~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\assign~1\assign~1.asm,,,,,, > assign~1.log
c:\_Masm\MP\link.exe assign~1.obj,,,,, >> assign~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\assign~1\assign~1.exe > c:\genera~1\output\semantic\assign~1\assign~1.txt
exit -1
