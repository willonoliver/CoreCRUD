/******************************************************************************/
/****        Generated by IBExpert 2024.1.22.1 16/09/2024 17:40:34         ****/
/******************************************************************************/

SET SQL DIALECT 3;

SET NAMES UTF8;

SET CLIENTLIB 'C:\Program Files (x86)\Firebird\Firebird_5_0\fbclient.dll';

CREATE DATABASE 'C:\CoreCRUD\CORECRUD.FDB'
USER 'SYSDBA' PASSWORD 'masterkey'
PAGE_SIZE 4096
DEFAULT CHARACTER SET UTF8 COLLATION UTF8;



/******************************************************************************/
/****                              Generators                              ****/
/******************************************************************************/

CREATE GENERATOR SEQ_CADCLIENTES START WITH 1 INCREMENT BY 1;
SET GENERATOR SEQ_CADCLIENTES TO 3;

CREATE GENERATOR SEQ_CADFORNECEDORES START WITH 1 INCREMENT BY 1;
SET GENERATOR SEQ_CADFORNECEDORES TO 0;

CREATE GENERATOR SEQ_CADPRODUTOS START WITH 1 INCREMENT BY 1;
SET GENERATOR SEQ_CADPRODUTOS TO 5;



/******************************************************************************/
/****                                Tables                                ****/
/******************************************************************************/



CREATE TABLE CADCLIENTES (
    ID                 INTEGER NOT NULL,
    NOMECLIENTE        VARCHAR(100) NOT NULL,
    NOMEFANTASIA       VARCHAR(100) NOT NULL,
    CNPJCPF            VARCHAR(14) NOT NULL,
    INSCRICAOESTADUAL  VARCHAR(20),
    ENDERECO           VARCHAR(100) NOT NULL,
    NUMERO             VARCHAR(4) NOT NULL,
    COMPLEMENTO        VARCHAR(10) NOT NULL,
    CEP                VARCHAR(8) NOT NULL,
    NOMECIDADE         VARCHAR(25) NOT NULL,
    UF                 CHAR(2) NOT NULL,
    CELULAR            VARCHAR(15) NOT NULL,
    TELEFONE           VARCHAR(15) NOT NULL,
    EMAIL              VARCHAR(100) NOT NULL,
    TIPOCLIENTE        CHAR(1) NOT NULL
);

CREATE TABLE CADEMPRESA (
    ID                 INTEGER NOT NULL,
    NOMEEMPRESA        VARCHAR(100),
    NOMEFANTASIA       VARCHAR(100),
    CNPJ               VARCHAR(20),
    INSCRICAOESTADUAL  VARCHAR(20),
    ENDERECO           VARCHAR(100),
    NUMERO             VARCHAR(10),
    COMPLEMENTO        VARCHAR(50),
    CEP                VARCHAR(10),
    NOMECIDADE         VARCHAR(50),
    UF                 VARCHAR(2),
    CELULAR            VARCHAR(15),
    TELEFONE           VARCHAR(15),
    EMAIL              VARCHAR(100),
    DATAALTERACAO      TIMESTAMP
);

CREATE TABLE CADFORNECEDORES (
    ID                 INTEGER NOT NULL,
    NOMEEMPRESA        VARCHAR(100),
    NOMEFANTASIA       VARCHAR(100),
    CNPJ               VARCHAR(20),
    INSCRICAOESTADUAL  VARCHAR(20),
    ENDERECO           VARCHAR(100),
    NUMERO             VARCHAR(10),
    COMPLEMENTO        VARCHAR(50),
    CEP                VARCHAR(10),
    NOMECIDADE         VARCHAR(50),
    UF                 VARCHAR(2),
    CELULAR            VARCHAR(15),
    TELEFONE           VARCHAR(15),
    EMAIL              VARCHAR(100),
    DATAALTERACAO      TIMESTAMP
);

CREATE TABLE CADPRODUTOS (
    ID_PRODUTO          INTEGER NOT NULL,
    NOME_PRODUTO        VARCHAR(100) NOT NULL,
    PRECO               NUMERIC(15,2) NOT NULL,
    QUANTIDADE_ESTOQUE  INTEGER NOT NULL
);

CREATE TABLE CADUSUARIOS (
    ID       INTEGER NOT NULL,
    USUARIO  VARCHAR(100) NOT NULL,
    SENHA    VARCHAR(255) NOT NULL
);



/******************************************************************************/
/****                          Check constraints                           ****/
/******************************************************************************/

ALTER TABLE CADCLIENTES ADD CHECK (TIPOCLIENTE IN ('F', 'J'));


/******************************************************************************/
/****                             Primary keys                             ****/
/******************************************************************************/

ALTER TABLE CADCLIENTES ADD PRIMARY KEY (ID);
ALTER TABLE CADEMPRESA ADD PRIMARY KEY (ID);
ALTER TABLE CADFORNECEDORES ADD PRIMARY KEY (ID);
ALTER TABLE CADPRODUTOS ADD PRIMARY KEY (ID_PRODUTO);
ALTER TABLE CADUSUARIOS ADD CONSTRAINT PK_CADUSUARIOS PRIMARY KEY (ID);


/******************************************************************************/
/****                               Triggers                               ****/
/******************************************************************************/



SET TERM ^ ;



/******************************************************************************/
/****                         Triggers for tables                          ****/
/******************************************************************************/



/* Trigger: BI_CADCLIENTES_ID */
CREATE TRIGGER BI_CADCLIENTES_ID FOR CADCLIENTES
ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
  IF (NEW.ID IS NULL) THEN
    NEW.ID = NEXT VALUE FOR SEQ_CADCLIENTES;
END
^

/* Trigger: BI_CADFORNECEDORES_ID */
CREATE TRIGGER BI_CADFORNECEDORES_ID FOR CADFORNECEDORES
ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
  IF (NEW.ID IS NULL) THEN
    NEW.ID = NEXT VALUE FOR SEQ_CADFORNECEDORES;
END
^

/* Trigger: BI_CADPRODUTOS_BI */
CREATE TRIGGER BI_CADPRODUTOS_BI FOR CADPRODUTOS
ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
  IF (NEW.ID_PRODUTO IS NULL) THEN
    NEW.ID_PRODUTO = NEXT VALUE FOR SEQ_CADPRODUTOS;
END
^
SET TERM ; ^



/******************************************************************************/
/****                                Roles                                 ****/
/******************************************************************************/

CREATE ROLE RDB$ADMIN;
