del c:\genera~1\output\semantic\assign~1\parant~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\assign~1\parant~1.asm,,,,,, > parant~1.log
c:\_Masm\MP\link.exe parant~1.obj,,,,, >> parant~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\assign~1\parant~1.exe > c:\genera~1\output\semantic\assign~1\parant~1.txt
exit -1
