CREATE DATABASE [JarvisDB];
GO

USE [JarvisDB];
GO


-- -----------------------------------------------------
-- Table `mydb`.`Utilizador`
-- -----------------------------------------------------
CREATE TABLE [Utilizador] (
  [idUtilizador] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Nome] VARCHAR(45) NOT NULL,
  [DataNascimento] DATE NOT NULL,
  [Username] VARCHAR(45) NOT NULL,
  [Password] VARCHAR(45) NOT NULL,
  [Email] VARCHAR(45) NOT NULL,
  [Foto] VARCHAR(45) NULL,
  [Admin] TINYINT NULL)
;
GO

-- -----------------------------------------------------
-- Table `mydb`.`Alimento`
-- -----------------------------------------------------
CREATE TABLE [Alimento] (
  [idAlimento] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Nome] VARCHAR(45) NOT NULL,
  [ValorNutricional] DECIMAL(5,2) NOT NULL,
  [Validade] DATE NULL)
;
GO

CREATE TABLE [Receita] (
  [idReceita] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Nome] VARCHAR(45) NOT NULL,
  [Descricao] VARCHAR(45) NULL,
  [Duracao] TIME NOT NULL)
;
GO


-- -----------------------------------------------------
-- Table `mydb`.`Avaliacao`
-- -----------------------------------------------------
CREATE TABLE [Avaliacao] (
  [idAvaliacao] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Classificacao] INT NULL,
  [Receita_idReceita] INT NOT NULL,
  [Utilizador_idUtilizador] INT NOT NULL
  ,
  CONSTRAINT [fk_Avaliacao_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Avaliacao_Utilizador1]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
	;
	GO

CREATE INDEX [fk_Avaliacao_Receita1_idx] ON [Avaliacao]([Receita_idReceita] ASC);
GO
CREATE  INDEX [fk_Avaliacao_Utilizador1_idx] ON [Avaliacao] ([Utilizador_idUtilizador] ASC);
GO  

-- -----------------------------------------------------
-- Table `mydb`.`Preferencia`
-- -----------------------------------------------------
CREATE TABLE [Preferencia] (
  [Utilizador_idUtilizador] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Alimento_idAlimento] INT NOT NULL,
  CONSTRAINT [fk_Utilizador_has_Alimento_Utilizador]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento1]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
CREATE INDEX [fk_Utilizador_has_Alimento_Alimento1_idx] ON [Preferencia] ([Alimento_idAlimento] ASC);
GO
CREATE  INDEX [fk_Utilizador_has_Alimento_Utilizador_idx] ON [Preferencia] ([Utilizador_idUtilizador] ASC);
GO


-- -----------------------------------------------------
-- Table `mydb`.`Alergia`
-- -----------------------------------------------------
CREATE TABLE [Alergia] (
  [Utilizador_idUtilizador] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Alimento_idAlimento] INT NOT NULL,
  CONSTRAINT [fk_Utilizador_has_Alimento_Utilizador1]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento2]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
  CREATE INDEX [fk_Utilizador_has_Alimento_Alimento2_idx] ON [Alergia] ([Alimento_idAlimento] ASC);
  GO
  CREATE INDEX [fk_Utilizador_has_Alimento_Utilizador1_idx] ON [Alergia] ([Utilizador_idUtilizador] ASC);
  GO


-- -----------------------------------------------------
-- Table `mydb`.`Despensa`
-- -----------------------------------------------------
CREATE TABLE [Despensa] (
  [Utilizador_idUtilizador] INTNOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Alimento_idAlimento] INT NOT NULL,
  CONSTRAINT [fk_Utilizador_has_Alimento_Utilizador2]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento3]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Alimento3_idx] ON [Despensa] ([Alimento_idAlimento] ASC);
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Utilizador2_idx] ON [Despensa] ([Utilizador_idUtilizador] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Receita_Alimento`
-- -----------------------------------------------------
CREATE TABLE [Receita_Alimento] (
  [Receita_idReceita] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Alimento_idAlimento] INT NOT NULL,
  [Quantidade] DECIMAL(5,2) NULL,
  CONSTRAINT [fk_Receita_has_Alimento_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Receita_has_Alimento_Alimento1]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Receita_has_Alimento_Alimento1_idx] ON [Receita_Alimento] ([Alimento_idAlimento] ASC);
GO
CREATE INDEX [fk_Receita_has_Alimento_Receita1_idx] ON [Receita_Alimento] ([Receita_idReceita] ASC);
GO


-- -----------------------------------------------------
-- Table `mydb`.`Instrução`
-- -----------------------------------------------------
CREATE TABLE [Instrução] (
  [idInstrução] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Descrição] VARCHAR(45) NULL,
  [Ordem] INT NULL,
  [Receita_idReceita] INT NOT NULL,
  CONSTRAINT [fk_Instrução_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Instrução_Receita1_idx] ON [Instrução] ([Receita_idReceita] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Histórico`
-- -----------------------------------------------------
CREATE TABLE [Histórico] (
  [Utilizador_idUtilizador] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Receita_idReceita] INT NOT NULL,
  CONSTRAINT [fk_Utilizador_has_Receita_Utilizador1]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Receita_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Utilizador_has_Receita_Receita1_idx] ON [Histórico] ([Receita_idReceita] ASC);
GO
CREATE INDEX [fk_Utilizador_has_Receita_Utilizador1_idx] ON [Histórico] ([Utilizador_idUtilizador] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Ementa`
-- -----------------------------------------------------
CREATE TABLE [Ementa] (
  [idEmenta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Data] DATE NOT NULL,
  [Utilizador_idUtilizador] INT NOT NULL,
  CONSTRAINT [fk_Ementa_Utilizador1]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Ementa_Utilizador1_idx] ON [Ementa] ([Utilizador_idUtilizador] ASC);
GO
-- -----------------------------------------------------
-- Table `mydb`.`Ementa_Receita`
-- -----------------------------------------------------
CREATE TABLE [Ementa_Receita] (
  [Ementa_idEmenta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [Receita_idReceita] INT NOT NULL,
  CONSTRAINT [fk_Ementa_has_Receita_Ementa1]
    FOREIGN KEY ([Ementa_idEmenta])
    REFERENCES [Ementa] ([idEmenta])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Ementa_has_Receita_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Ementa_has_Receita_Receita1_idx] ON [Ementa_Receita] ([Receita_idReceita] ASC);
GO
CREATE INDEX [fk_Ementa_has_Receita_Ementa1_idx] ON [Ementa_Receita] ([Ementa_idEmenta] ASC);
GO
