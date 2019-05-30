DROP DATABASE [JarvisDB];
GO

CREATE DATABASE [JarvisDB];
GO

USE [JarvisDB];
GO

-- -----------------------------------------------------
-- Table `mydb`.`Utilizador`
-- -----------------------------------------------------
CREATE TABLE [Utilizador] (
  [idUtilizador] INT NOT NULL,
  [Nome] VARCHAR(45) NOT NULL,
  [DataNascimento] DATE NOT NULL,
  [Username] VARCHAR(45) NOT NULL,
  [Password] VARCHAR(45) NOT NULL,
  [Email] VARCHAR(45) NOT NULL,
  [Foto] VARCHAR(45) NULL,
  [Admin] TINYINT NULL,
  PRIMARY KEY ([idUtilizador]))
;
GO

-- -----------------------------------------------------
-- Table `mydb`.`Alimento`
-- -----------------------------------------------------
CREATE TABLE [Alimento] (
  [idAlimento] INT NOT NULL,
  [Nome] VARCHAR(45) NOT NULL,
  [ValorNutricional] DECIMAL(5,2) NOT NULL,
  [Validade] DATE NULL,
  PRIMARY KEY ([idAlimento]))
;
GO

CREATE TABLE [Receita] (
  [idReceita] INT NOT NULL,
  [Nome] VARCHAR(45) NOT NULL,
  [Descricao] VARCHAR(150) NULL,
  [Duracao] INT NOT NULL,
  [Dificuldade] VARCHAR(20) NOT NULL,
  [Classificacao] DECIMAL(5,2) NOT NULL,
  PRIMARY KEY ([idReceita]))
;
GO


-- -----------------------------------------------------
-- Table `mydb`.`Avaliacao`
-- -----------------------------------------------------
CREATE TABLE [Avaliacao] (
  [idAvaliacao] INT NOT NULL,
  [Classificacao] INT NULL,
  [Receita_idReceita] INT NOT NULL,
  [Utilizador_idUtilizador] INT NOT NULL,
  PRIMARY KEY ([idAvaliacao])
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
  [Utilizador_idUtilizador] INT NOT NULL,
  [Alimento_idAlimento] INT NOT NULL,
  PRIMARY KEY ([Utilizador_idUtilizador], [Alimento_idAlimento]),
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
  [Utilizador_idUtilizador] INT NOT NULL,
  [Alimento_idAlimento] INT NOT NULL,
  PRIMARY KEY ([Utilizador_idUtilizador], [Alimento_idAlimento]),
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
  [Utilizador_idUtilizador] INT NOT NULL,
  [Alimento_idAlimento] INT NOT NULL,
  PRIMARY KEY ([Utilizador_idUtilizador], [Alimento_idAlimento]),
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
  [Receita_idReceita] INT NOT NULL,
  [Alimento_idAlimento] INT NOT NULL,
  [Quantidade] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([Receita_idReceita], [Alimento_idAlimento]),
  CONSTRAINT [fk_Receita_has_Alimento_Receita1]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Receita_has_Alimento_Alimento4]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Receita_has_Alimento_Alimento4_idx] ON [Receita_Alimento] ([Alimento_idAlimento] ASC);
GO
CREATE INDEX [fk_Receita_has_Alimento_Receita1_idx] ON [Receita_Alimento] ([Receita_idReceita] ASC);
GO


-- -----------------------------------------------------
-- Table `mydb`.`Instrução`
-- -----------------------------------------------------
CREATE TABLE [Instrução] (
  [idInstrução] INT NOT NULL,
  [Descrição] VARCHAR(300) NULL,
  [Ordem] INT NULL,
  [Receita_idReceita] INT NOT NULL,
  PRIMARY KEY ([idInstrução]),
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
  [Utilizador_idUtilizador] INT NOT NULL,
  [Receita_idReceita] INT NOT NULL,
  PRIMARY KEY ([Utilizador_idUtilizador], [Receita_idReceita]),
  CONSTRAINT [fk_Utilizador_has_Receita_Utilizador3]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Receita_Receita2]
    FOREIGN KEY ([Receita_idReceita])
    REFERENCES [Receita] ([idReceita])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Utilizador_has_Receita_Receita2_idx] ON [Histórico] ([Receita_idReceita] ASC);
GO
CREATE INDEX [fk_Utilizador_has_Receita_Utilizador3_idx] ON [Histórico] ([Utilizador_idUtilizador] ASC);
GO

-- -----------------------------------------------------
-- Table `mydb`.`Ementa`
-- -----------------------------------------------------
CREATE TABLE [Ementa] (
  [idEmenta] INT NOT NULL,
  [Data] DATE NOT NULL,
  [Utilizador_idUtilizador] INT NOT NULL,
  PRIMARY KEY ([idEmenta]),
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
  [Ementa_idEmenta] INT NOT NULL,
  [Receita_idReceita] INT NOT NULL,
  PRIMARY KEY ([Ementa_idEmenta], [Receita_idReceita]),
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


-- -----------------------------------------------------
-- Table `mydb`.`ListaCompras`
-- -----------------------------------------------------
CREATE TABLE [ListaCompras] (
  [Utilizador_idUtilizador] INT NOT NULL,
  [Alimento_idAlimento] INT NOT NULL,
  PRIMARY KEY ([Utilizador_idUtilizador], [Alimento_idAlimento]),
  CONSTRAINT [fk_Utilizador_has_Alimento_Utilizador3]
    FOREIGN KEY ([Utilizador_idUtilizador])
    REFERENCES [Utilizador] ([idUtilizador])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento5]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Alimento5_idx] ON [ListaCompras] ([Alimento_idAlimento] ASC);
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Utilizador3_idx] ON [ListaCompras] ([Utilizador_idUtilizador] ASC);
GO


-- -----------------------------------------------------
-- Table `mydb`.`Alimento_Alternativo`
-- -----------------------------------------------------
CREATE TABLE [Alimento_Alternativo] (
  [Alimento_idAlimento] INT NOT NULL,
  [Alimento_idAlimentoAlt] INT NOT NULL,
  PRIMARY KEY ([Alimento_idAlimento], [Alimento_idAlimentoAlt]),
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento6]
    FOREIGN KEY ([Alimento_idAlimento])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Utilizador_has_Alimento_Alimento7]
    FOREIGN KEY ([Alimento_idAlimentoAlt])
    REFERENCES [Alimento] ([idAlimento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Alimento6_idx] ON [Alimento_Alternativo] ([Alimento_idAlimento] ASC);
GO
CREATE INDEX [fk_Utilizador_has_Alimento_Alimento7_idx] ON [Alimento_Alternativo] ([Alimento_idAlimento] ASC);
GO