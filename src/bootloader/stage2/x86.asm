bits 16

section _TEXT class=CODE

;
; int 10h ah=0Eh
; args: character, type
;
global _x86_Video_WriteCharTeletype
_x86_Video_WriteCharTeletype:
    
    ; make new call frame
    push bp             ; save old call frame
    mov bp, sp          ; initialize new call frame

    ; save bx
    push bx

    ; [bp+0] - old call frame
    ; [bp+2] - return address (small memory model => 2 bytes)
    ; [bp+4] - first argument (character); bytes are converted to words
    ; [bp+6] - second argument (page)
    ; !: bytes are converted to words
    mov ah, 0Eh
    mov al, [bp + 4]
    mov bh, [bp + 6]

    int 10h

    ; restore bx
    pop bx

    ; restore old call frame
    mov sp, bp
    pop bp
    ret