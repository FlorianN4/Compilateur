del c:\genera~1\output\semantic\instru~1\mul_pr~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\instru~1\mul_pr~1.asm,,,,,, > mul_pr~1.log
c:\_Masm\MP\link.exe mul_pr~1.obj,,,,, >> mul_pr~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\instru~1\mul_pr~1.exe > c:\genera~1\output\semantic\instru~1\mul_pr~1.txt
exit -1
