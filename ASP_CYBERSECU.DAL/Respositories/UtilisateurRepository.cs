using ASP_CYBERSECU.DAL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_CYBERSECU.DAL.Respositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {

        private readonly SqlConnection _connection;

        public UtilisateurRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM UTILISATEUR";
                command.CommandType = CommandType.Text;

                _connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        utilisateurs.Add(
                            new Utilisateur 
                            {
                                Id = reader.GetInt32("id"),
                                Username = reader.GetString("username"),
                                Email = reader.GetString("email")
                            }
                        );
                    }
                    _connection.Close();
                    return utilisateurs;
                }

            }
        }

        public Utilisateur? GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Utilisateur? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Utilisateur? Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Utilisateur? Register(Utilisateur utilisateur)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "dbo.[Register]";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", utilisateur.Username);
                command.Parameters.AddWithValue("@Email", utilisateur.Email);
                command.Parameters.AddWithValue("@Password", utilisateur.Password);

                _connection.Open();
                utilisateur.Id = (int)command.ExecuteScalar();
                _connection.Close();
                return utilisateur;
            }
        }

        public Utilisateur? UpdateUtilisateur(int id, Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
