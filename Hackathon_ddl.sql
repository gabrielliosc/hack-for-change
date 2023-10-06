
/*Criação das tabelas e Primary keys*/

CREATE TABLE alternativas (
    id_alternativa            INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    alternativa_texto         VARCHAR2(255),
    alternativa_img           BLOB,
    id_fase                   INTEGER NOT NULL,
    id_tipo                   INTEGER NOT NULL,
    PRIMARY KEY (id_alternativa)
);

CREATE TABLE fases (
    id_fase        INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    nome_fase      VARCHAR2(50),
    pergunta_label VARCHAR2(255),
    id_mapa  INTEGER NOT NULL,
    PRIMARY KEY (id_fase)
);

CREATE TABLE mapas (
    id_mapa             INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    nome_mapa           VARCHAR2(50) NOT NULL,
    nivel               NUMERIC NOT NULL,
    id_materia INTEGER NOT NULL,
    PRIMARY KEY (id_mapa)
);

CREATE TABLE materias (
    id_materia   INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    nome_materia VARCHAR2(50) NOT NULL,
    desc_materia VARCHAR2(255) NOT NULL,
    PRIMARY KEY (id_materia)
);

CREATE TABLE tipo_alternativas (
    id_tipo INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    tipo    VARCHAR2(50) NOT NULL,
    PRIMARY KEY (id_tipo)
);

CREATE TABLE usuarios (
    id_usuario        INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    nome_usuario      VARCHAR2(255) NOT NULL,
    dt_nascimento     DATE NOT NULL,
    senha             VARCHAR2(50) NOT NULL,
    email             VARCHAR2(255) NOT NULL,
    passos            CHAR(1) NOT NULL,
    pontuacao_usuario INTEGER,
    dt_cadastro       DATE NOT NULL,
    coins             INTEGER,
    img_perfil        BLOB,
    PRIMARY KEY (id_usuario)
);

/*Deixando como padrão a data de cadastro para na qual foi cadastrado*/
ALTER TABLE usuarios MODIFY (dt_cadastro DEFAULT SYSDATE);

CREATE TABLE usuario_mapas (
    id_usuario_mapas            INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    status_mapa                 VARCHAR2(50) NOT NULL,
    pontuacao_mapa              INTEGER,
    id_usuario                  INTEGER NOT NULL,
    id_mapa                     INTEGER NOT NULL,
    PRIMARY KEY (id_usuario_mapas)
);

/*Criação das Foregein keys*/
ALTER TABLE alternativas
    ADD CONSTRAINT alternativas_fases_fk FOREIGN KEY ( id_fase )
        REFERENCES fases ( id_fase );

ALTER TABLE alternativas
    ADD CONSTRAINT tipo_alternativas_fk FOREIGN KEY ( id_tipo )
        REFERENCES tipo_alternativas ( id_tipo );
        
ALTER TABLE fases
    ADD CONSTRAINT fases_mapas_fk FOREIGN KEY ( id_mapa )
        REFERENCES mapas ( id_mapa );

ALTER TABLE mapas
    ADD CONSTRAINT mapas_materia_fk FOREIGN KEY ( id_materia )
        REFERENCES materias ( id_materia );

ALTER TABLE usuario_mapas
    ADD CONSTRAINT usuarios_mapas__fk FOREIGN KEY ( id_mapa )
        REFERENCES mapas ( id_mapa);
        
ALTER TABLE usuario_mapas
    ADD CONSTRAINT usuario_mapas_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES usuarios ( id_usuario );
        
    /*Restrições de colunas - CHECKS */

/*Restrição para que a "coins" não possam ser negativa*/
ALTER TABLE usuarios
    ADD CONSTRAINT coins_positivas_ck
        CHECK ( coins >= 0 );

/*Restrição para que a "pontuacao_usuario" não possa ser negativa*/
ALTER TABLE usuarios
    ADD CONSTRAINT pontuacao_usuario_positiva_ck
        CHECK ( pontuacao_usuario >= 0 );
  
/*Restrição para que a "pontuacao_mapa" não possa ser negativa*/      
ALTER TABLE usuario_mapas
    ADD CONSTRAINT pontuacao_mapa_ck
        CHECK ( pontuacao_mapa >= 0 );

/*Restrição para que o status esteja entre 'EM ANDAMENTO' e 'CONCLUIDO'*/
ALTER TABLE usuario_mapas
    ADD CONSTRAINT status_mapa_tipo_ck
        CHECK ( status_mapa IN('EM ANDAMENTO', 'CONCLUIDO') );

/*Restrição para que a "nivel" não possa ser negativa*/           
ALTER TABLE  mapas
    ADD CONSTRAINT nivel_positivo_ck
        CHECK ( nivel >= 0 );

/*Restrição para que a data de nascimento não possa ser maior que a data de cadastro*/    
ALTER TABLE usuarios
    ADD CONSTRAINT dt_nascimento_menor_dt_cadastro_ck
        CHECK ( dt_nascimento < dt_cadastro );
        
/*Restrição para que a opção passos seja um boolean, seja 0 ou 1 ( False ou True)*/



    /*Inserção de dados testes - Inserts*/

/*Inserção da tabela materias*/
INSERT INTO materias ( nome_materia, desc_materia )VALUES ( 'Matematica', 'Operações matemáticas e lógica.' );
INSERT INTO materias ( nome_materia, desc_materia )VALUES ( 'Português', 'Gramática, leitura, entendimento de texto e produção textual.' );
    
/*Inserção na tabela tipo_alternativas*/
INSERT INTO tipo_alternativas ( tipo )VALUES ( 'Texto' );
INSERT INTO tipo_alternativas ( tipo )VALUES ( 'Imagem' );

/*Inserção na tabela usuario*/
INSERT INTO usuarios ( nome_usuario, dt_nascimento, passos, senha, email, pontuacao_usuario, coins )
    VALUES ( 'Jaul', '11/08/2004', 0, '12345', 'email@email.com.br', 78, 54 );
INSERT INTO usuarios ( nome_usuario, dt_nascimento, passos, senha, email, pontuacao_usuario )
    VALUES ( 'Alexandre', '24/04/1998', 0, 'senha', 'alezao@mail.com', 100 );
    
/*Inserção na tabela mapas*/
INSERT INTO mapas ( nome_mapa, nivel, id_materia ) VALUES ( 'Adição', 1, 1 );
INSERT INTO mapas ( nome_mapa, nivel, id_materia ) VALUES ( 'Função de 2º grau', 3, 1 ); 
INSERT INTO mapas ( nome_mapa, nivel, id_materia ) VALUES ( 'Substantivos', 2, 2 );  
INSERT INTO mapas ( nome_mapa, nivel, id_materia ) VALUES ( 'Período Simples', 3, 2 );  

/*Inserção na tabela usuario_mapas*/
INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'CONCLUIDO', 79, 1, 1 );
INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'EM ANDAMENTO', 57, 1, 4 );
INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'CONCLUIDO', 100, 1, 2 );

INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'CONCLUIDO', 100, 2, 3 );
INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'EM ANDAMENTO', 12, 2, 1 );
INSERT INTO usuario_mapas ( status_mapa, pontuacao_mapa, id_usuario, id_mapa )VALUES ( 'EM ANDAMENTO', 6, 2, 4 );

/*Inserção na tabela fases*/
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa ) VALUES ( 'Adição - 1', 'Quanto é 2 + 2', 1 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa ) VALUES ( 'Adição - 2', 'Quanto é 4 + 3', 1 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa ) VALUES ( 'Adição - 3', 'Quanto é 7 + 7', 1 );

INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Função de 2º - 1', 'O valor máximo da função f : IR ? IR definida por f(x) = –x^2 + 6x + 7 é:', 1 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Função de 2º - 2', 'Seja a função f, de IR em IR, definida por f(x) = –x^2 – 8x + 12. Essa função não pode assumir valores maiores que:', 1 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Função de 2º - 3', 'O valor extremo da função y = x^2 – 8x + 15 é:', 1 );

INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Substantivo - 1', 'Qual das palavras destacadas abaixo não representa um substantivo abstrato:', 3);
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Substantivo - 2', 'Os substantivos primitivos são palavras que não derivam de outras. De acordo com isso, a alternativa abaixo que contempla um substantivo primitivo e um derivado é:', 3);
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Substantivo - 3', '“O mundo precisa de pessoas *boas*.” Na frase acima, se a palavra destacada for substituída por um substantivo abstrato ficaria', 3);

INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Período Simples - 1', ' Na frase “A urna eletrônica foi recebida *pelo cidadão*” o termo em destaque é classificado como:', 4 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Período Simples - 2', 'Na frase: “Afinal uma das *tartarugas* murmurou”: a palavra sublinhada exerce a função de:', 4 );
INSERT INTO fases ( nome_fase, pergunta_label, id_mapa )
    VALUES ( 'Período Simples - 3', 'Em “O Brasil, *um país maior que a parte continental dos Estados Unidos*, realizou…” (linha 4), a parte em destaque corresponde a um:', 4 );
    
/*Inserção na tabela alternativas*/

/*Inserção no mapa: adição*/
/*Fase: 1*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '4', 1, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '5', 1, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '3', 1, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '6', 1, 1 );

/*Fase: 2*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '6', 2, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '5', 2, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '7', 2, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '8', 2, 1 );

/*Fase: 3*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '11', 3, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '16', 3, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '13', 3, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '14', 3, 1 );
    
/*Inserção no mapa: Equação de 2º*/
/*Fase: 1*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '7', 4, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '6', 4, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '3', 4, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '16', 4, 1 );

/*Fase: 2*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '20', 5, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '22', 5, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '26', 5, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '28', 5, 1 );

/*Fase: 3*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '11', 6, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '16', 6, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '13', 6, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo ) VALUES ( '14', 6, 1 );
    
    
/*Inserção na fase: substantivo*/
/*Fase: 1*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'A sua *conquista* se deve ao seu esforço.', 7, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'A *humildade* é a sua principal característica.', 7, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'A sua *aprendizagem* é bastante rápida', 7, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'Muitos *idosos* têm problemas de saúde.', 7, 1 );

/*Fase: 2*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'anel - papel', 8, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'pedras - rochas', 8, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'árvores - plantas', 8, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'profissão - sapataria', 8, 1 );

/*Fase: 3*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'O mundo precisa de boa-fé.', 9, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'O mundo precisa de boa sorte.', 9, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'O mundo precisa de bondade.', 9, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'O mundo precisa de bons e ruins.', 9, 1 );
    
/*Inserção na fase: Período Simples*/
/*Fase: 1*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'adjunto adverbial de modo', 10, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'objeto direto', 10, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'agente da passiva', 10, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'aposto', 10, 1 );

/*Fase: 2*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'sujeito', 11, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'complemento', 11, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'adjunto nominal', 11, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'complemento nominal', 11, 1 );

/*Fase: 3*/
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'predicativo', 12, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'vocativo', 12, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'sujeito simples', 12, 1 );
INSERT INTO alternativas ( alternativa_texto, id_fase, id_tipo )
    VALUES ( 'aposto', 12, 1 );
    
/* Visualização dos dados da tabela
SELECT * FROM alternativas;
SELECT * FROM fases;
SELECT * FROM mapas;
SELECT * FROM materias;
SELECT * FROM tipo_alternativas;
SELECT * FROM usuarios;
SELECT * FROM usuario_mapas;
*/

/*   Drop das tabelas  
DROP TABLE alternativas CASCADE CONSTRAINTS;
DROP TABLE fases CASCADE CONSTRAINTS;
DROP TABLE mapas CASCADE CONSTRAINTS;
DROP TABLE materias CASCADE CONSTRAINTS;
DROP TABLE tipo_alternativas CASCADE CONSTRAINTS;
DROP TABLE usuarios CASCADE CONSTRAINTS;
DROP TABLE usuario_mapas CASCADE CONSTRAINTS;
*/