main:
    movconst    $0, 255
    imult       $0, $0

    movconst    $1, 255
    movconst    $2, 2
    imult       $1, $2
    add         $0, $1

    movconst    $3, 64
    imult       $3, $3
    
loop:
    store       $3, $0
    inc         $3
    jump        loop