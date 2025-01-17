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
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM UTILISATEUR WHERE id = @id";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                int nbrRow = command.ExecuteNonQuery();
                _connection.Close();

                return nbrRow > 0;

            }
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM UTILISATEUR";
                command.CommandType = CommandType.Text;

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
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
            Utilisateur? utilisateur = null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, username, email Utilisateur WHERE email = @email";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@email", email);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        utilisateur = new Utilisateur
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email")
                        };
                    }

                    _connection.Close();
                    return utilisateur;
                }

            }
        }

        public Utilisateur? GetById(int id)
        {
            Utilisateur? utilisateur = null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, username, email FROM Utilisateur WHERE id = @id";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        utilisateur = new Utilisateur
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email")
                        };
                    }

                    _connection.Close();
                    return utilisateur;
                }

            }
        }

        public Utilisateur? Login(string email, string password)
        {
            Utilisateur? utilisateur = null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "dbo.[Login]";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        utilisateur = new Utilisateur
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email")
                        };
                    }
                }
                _connection.Close();
                return utilisateur;
            }
        }
        public Utilisateur? Register(Utilisateur utilisateur)
        {
            using (SqlCommand command = _connection.CreateCommand())
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

        public Utilisateur? UpdateUtilisateur(Utilisateur utilisateur)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE UTILISATEUR SET username = @username, email = @email  WHERE id = @id";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", utilisateur.Id);
                command.Parameters.AddWithValue("@username", utilisateur.Username);
                command.Parameters.AddWithValue("@email", utilisateur.Email);
                _connection.Open();
                int nbrRow = command.ExecuteNonQuery();
                _connection.Close();

                return nbrRow > 0 ? utilisateur : null;
            }
        }
    }
}
