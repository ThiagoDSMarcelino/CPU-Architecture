main:
    movconst    $0, 1
    movconst    $1, 64
    movconst    $2, 32
    imult       $1, $1
    add         $1, $2
    store       $1, $0