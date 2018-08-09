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
            comando.CommandText = "SELECT id,nome,matricula,nota01,nota02,nota03,frequencia, faltas FROM alunos";
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
            comando.CommandText = @"INSERT INTO alunos (nome,matricula,nota01,nota02,nota03,frequencia,faltas) OUTPUT
            INSERTED.ID VALUES (@NOME, @MATRICULA, @NOTA01, @NOTA02, @NOTA03, @FREQUENCIA, @FALTAS)";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@MATRICULA", aluno.Matricula);
            comando.Parameters.AddWithValue("@NOTA01", aluno.Nota1);
            comando.Parameters.AddWithValue("@NOTA02", aluno.Nota2);
            comando.Parameters.AddWithValue("@NOTA03", aluno.Nota3);
            comando.Parameters.AddWithValue("@FREQUENCIA", aluno.frequencia);
            comando.Parameters.AddWithValue("@FALTAS", aluno.Faltas);
            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            return id;


        }

        public bool Alterar(Alunos aluno)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "UPDATE alunos SET nome = @NOME, matricula = @MATRICULA, nota01 = @NOTA01, nota02 = @NOTA02, nota03 = NOTA03, frequencia = @FREQUENCIA, faltas = @FALTAS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@MATRICULA", aluno.Matricula);
            comando.Parameters.AddWithValue("@NOTA01", aluno.Nota1);
            comando.Parameters.AddWithValue("@NOTA02", aluno.Nota2);
            comando.Parameters.AddWithValue("@NOTA03", aluno.Nota3);
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
            comando.CommandText = "SELECT nome,matricula,nota01,nota02,nota03,frequencia, faltas FROM alunos WHERE id = @ID";
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