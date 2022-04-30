del c:\genera~1\output\semantic\instru~1\sub_pr~1.exe
c:\_Masm\MP\masm.exe c:\genera~1\output\semantic\instru~1\sub_pr~1.asm,,,,,, > sub_pr~1.log
c:\_Masm\MP\link.exe sub_pr~1.obj,,,,, >> sub_pr~1.log
del *.crf
del *.lst
del *.obj
del *.map
c:\genera~1\output\semantic\instru~1\sub_pr~1.exe > c:\genera~1\output\semantic\instru~1\sub_pr~1.txt
exit -1
