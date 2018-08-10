using Model.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Model.Repositório
{
    public class AlunosRepositorio
    {

        public List<Alunos> ObterTodos()
        {
            List<Alunos> alunos = new List<Alunos>();
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "SELECT id,nome,codigo_matricula,nota_01,nota_02,nota_03,frequencia, faltas FROM aluno";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            foreach (DataRow linha in tabela.Rows)
            {
                Alunos aluno = new Alunos()

                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    Matricula = linha[2].ToString(),
                    Nota1 = Convert.ToDouble(linha[3].ToString()),
                    Nota2 = Convert.ToDouble(linha[4].ToString()),
                    Nota3 = Convert.ToDouble(linha[5].ToString()),
                    frequencia = Convert.ToInt32(linha[6].ToString()),
                    Faltas = Convert.ToInt16(linha[7].ToString())
                };
                alunos.Add(aluno);
            }
            return alunos;

        }

        public int Cadastrar(Alunos aluno)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = @"INSERT INTO alunos (nome,codigo_matricula,nota_01,nota_02,nota_03,frequencia,faltas) OUTPUT
            INSERTED.ID VALUES (@NOME, @CODIGO_MATRICULA, @NOTA_01, @NOTA_02, @NOTA_03, @FREQUENCIA, @FALTAS)";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@CODIGO_MATRICULA", aluno.Matricula);
            comando.Parameters.AddWithValue("@NOTA_01", aluno.Nota1);
            comando.Parameters.AddWithValue("@NOTA_02", aluno.Nota2);
            comando.Parameters.AddWithValue("@NOTA_03", aluno.Nota3);
            comando.Parameters.AddWithValue("@FREQUENCIA", aluno.frequencia);
            comando.Parameters.AddWithValue("@FALTAS", aluno.Faltas);
            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            return id;


        }

        public bool Alterar(Alunos aluno)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "UPDATE alunos SET nome = @NOME, codigo_matricula = @CODIGO_MATRICULA, nota_01 = @NOTA_01, nota_02 = @NOTA_02, nota_03 = NOTA_03, frequencia = @FREQUENCIA, faltas = @FALTAS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@CODIGO_MATRICULA", aluno.Matricula);
            comando.Parameters.AddWithValue("@NOTA_01", aluno.Nota1);
            comando.Parameters.AddWithValue("@NOTA_02", aluno.Nota2);
            comando.Parameters.AddWithValue("@NOTA_03", aluno.Nota3);
            comando.Parameters.AddWithValue("@FREQUENCIA", aluno.frequencia);
            comando.Parameters.AddWithValue("@FALTAS", aluno.Faltas);
            comando.Parameters.AddWithValue("@ID", aluno.Id);

            return comando.ExecuteNonQuery() == 1;
        }


        public bool Excluir(int id)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "DELETE FROM alunos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            return comando.ExecuteNonQuery() == 1;

        }

        public Alunos ObterPeloID(int id)
        {
            Alunos aluno = null;
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "SELECT nome,codigo_matricula,nota_01,nota_02,nota_03,frequencia, faltas FROM alunos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                aluno = new Alunos();
                aluno.Id = Convert.ToInt32(tabela.Rows[0][0].ToString());
                aluno.Nome = tabela.Rows[0][1].ToString();
                aluno.Matricula = tabela.Rows[0][2].ToString();
                aluno.Nota1 = Convert.ToDouble(tabela.Rows[0][3].ToString());
                aluno.Nota2 = Convert.ToDouble(tabela.Rows[0][4].ToString());
                aluno.Nota3 = Convert.ToDouble(tabela.Rows[0][5].ToString());
                aluno.frequencia = Convert.ToInt32(tabela.Rows[0][6].ToString());
                aluno.Faltas = Convert.ToInt16(tabela.Rows[0][7].ToString());



            }
                return aluno;
        }
    }
}