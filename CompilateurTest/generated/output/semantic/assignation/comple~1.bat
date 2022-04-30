del c:\genera~1\output\semantic\assign~1\comple~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\assign~1\comple~1.asm,,,,,, > comple~1.log
c:\_Masm\MP\link.exe comple~1.obj,,,,, >> comple~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\assign~1\comple~1.exe > c:\genera~1\output\semantic\assign~1\comple~1.txt
exit -1
