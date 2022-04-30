data segment
    msg db "My message$"
    x dw 0
data ends

code segment
    assume cs:code, ds:data
start:
    mov ax, data
    mov ds, ax
    mov dx, offset msg
    mov ah, 09h
    int 21h
    
    mov ax, 45612
    call print_ax
    call print_nl

    mov ah, 4ch
    int 21h


PUSHA    MACRO  
    push ax
    push bx
    push cx
    push dx
    push bp
    push si
    push di
ENDM

POPA MACRO
    pop di
    pop si
    pop bp
    pop dx
    pop cx
    pop bx
    pop ax
ENDM


print_nl PROC 
    PUSH AX  
    PUSH DX 
    MOV AH, 2
    MOV DL, 0Dh
    INT 21h
    MOV DL, 0Ah
    INT 21h
    POP DX 
    POP AX
    RET
print_nl ENDP

;------------------------------------------------
;  Affiche la valeur entiere de AX 
;------------------------------------------------
print_ax PROC
CMP AX, 0
JNE print_ax_r
    PUSH AX
    MOV DL, '0'
    MOV AH, 02h
    INT 21h
    POP AX
    RET 
print_ax_r:
    PUSHA
    MOV DX, 0
    CMP AX, 0
    JE pn_done
    MOV BX, 10
    DIV BX
    CALL print_ax_r
    MOV AX, DX
    ADD AL, 30h
    MOV DL, AL
    MOV AH, 02h
    INT 21h
    JMP pn_done
pn_done:
    POPA
    RET
print_ax ENDP

code ends
end start