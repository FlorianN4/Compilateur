lexer grammar KIWI;

// Words
PRINT: 'print';
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

TYPE: (BYTE | WORD | STRING);
BYTE: 'byte';
WORD: 'word';
STRING: 'string';




ID: LETTER (DIGIT | LETTER)*;
ENTIER: (NUMBER | BIT8 | BIT16 | HEXA8 | HEXA16);
NUMBER: (DIGIT)+;
HEXA8: 'HEXA HEXA';
HEXA16: 'HEXA HEXA HEXA HEXA';
BIT8: 'BIT BIT BIT BIT BIT BIT BIT BIT';
BIT16: 'BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT BIT';
STRINGLITTERAL: '"' (.)*? '"';
VARIABLE: TYPE ID;
CONSTANTE: 'const ID (ENTIER | CHAINE)';

fragment DIGIT: [0-9] ;
fragment SPECIAL: [. , ;];
fragment LETTER: [a-zA-Z];
fragment BIT: [0-1];
fragment HEXA: [0-9a-fA-F];


// Whitespaces -> ignored
NEWLINE: '\r'? '\n'  -> skip ;
WS: [ \t]+ -> skip ;
COMMENT: '#' ~('\r'|'\n')* -> skip;


unknowns : Unknown+ ; 
Unknown  : . ; 