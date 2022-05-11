lexer grammar KIWI;

// Words
PRINT: 'print';
SOUS: 'Soustraction';
SUM: 'Sum';
RETURN: 'return';
LPAR: '(';
RPAR: ')';
LBRACE: '{';
RBRACE: '}';
COMMA: ',';
PLUS: '+';
PLUSPLUS: '++';
MINUSMINUS: '--';
MINUS: '-';
DIV: '/';
MUL: '*';
MODULO: '%';
AND: '&';
OR: '|';
XOR: '^';
NOT: '!';
EQUAL: '=';
SHIFTD: '<<';
SHIFTG: '>>';

BEGIN: 'Begin';
END: 'End';

TRUE: 'TRUE';
FALSE: 'FALSE';
NOP: 'NOP';

BYTE: 'byte';
WORD: 'word';
STRING: 'string';
CONST: 'const';



ID: LETTER (DIGIT | LETTER)*;
//ENTIER: (NUMBER | BIT8 | BIT16 | HEXA8 | HEXA16);
NUMBER: (DIGIT)+;
HEXA8:'0x'HEXA HEXA;
HEXA16:'0x'HEXA HEXA HEXA HEXA;
BIT8:'0b'BIT BIT BIT BIT BIT BIT BIT BIT;
BIT16:'0b'BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT;
STRINGLITTERAL: '"' (.)*? '"';

fragment DIGIT: [0-9] ;
fragment SPECIAL: [.,;];
fragment LETTER: [a-zA-Z];
fragment BIT: [0-1];
fragment HEXA: [0-9a-fA-F];


// Whitespaces -> ignored
NEWLINE: '\r'? '\n'  -> skip ;
WS: [ \t]+ -> skip ;
COMMENT: '#' ~('\r'|'\n')* -> skip;


unknowns : Unknown+ ; 
Unknown  : . ; 