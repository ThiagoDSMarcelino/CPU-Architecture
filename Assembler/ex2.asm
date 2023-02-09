main:
    movconst    $0, 255
    movconst    $1, 255
    movconst    $2, 2
    movconst    $3, 64
    imult       $0, $0
    imult       $1, $2
    imult       $3, $3
    add         $0, $1
    store       $3, $0