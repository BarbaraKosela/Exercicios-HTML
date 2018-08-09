DROP TABLE aluno;
CREATE TABLE aluno(

id INT IDENTITY (1,1) PRIMARY KEY,
nome VARCHAR(100) NOT NULL,
codigo_matricula VARCHAR(100) NOT NULL,
nota_01 REAL NOT NULL,
nota_02 REAL NOT NULL,
nota_03 REAL NOT NULL,
frequencia TINYINT,
faltas TINYINT

);

INSERT INTO aluno(nome,codigo_matricula,nota_01,nota_02,nota_03, frequencia, faltas) VALUES 
('Josézinho', '52', 5, 3, 9, 95, 5);