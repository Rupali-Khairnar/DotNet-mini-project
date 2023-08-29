using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Recipe_Sharing_platform.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string ? Title { get; set; }

        [Required]
        public string ? Ingredients { get; set; }

        [Required]
        public string ? Instructions { get; set; }
        public static List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipePlatform;Integrated Security=True;Connect Timeout=30";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Recipe";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    recipes.Add(new Recipe
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Ingredients = reader.GetString(2),
                        Instructions = reader.GetString(3)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return recipes;
        }
        public static Recipe GetRecipeById(int id)
        {
            Recipe recipe = new Recipe();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipePlatform;Integrated Security=True;Connect Timeout=30";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Recipe WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    recipe.Id = reader.GetInt32(0);
                    recipe.Title = reader.GetString(1);
                    recipe.Ingredients = reader.GetString(2);
                    recipe.Instructions = reader.GetString(3);
                }
                else
                {
                    recipe = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return recipe;
        }

        public static void InsertRecipe(Recipe recipe)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipePlatform;Integrated Security=True;Connect Timeout=30";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Recipe (Title, Ingredients, Instructions) VALUES (@Title, @Ingredients, @Instructions)";
                command.Parameters.AddWithValue("@Title", recipe.Title);
                command.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                command.Parameters.AddWithValue("@Instructions", recipe.Instructions);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void UpdateRecipe(Recipe recipe)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipePlatform;Integrated Security=True;Connect Timeout=30";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE Recipe SET Title = @Title, Ingredients = @Ingredients, Instructions = @Instructions WHERE Id = @Id";
                command.Parameters.AddWithValue("@Title", recipe.Title);
                command.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                command.Parameters.AddWithValue("@Instructions", recipe.Instructions);
                command.Parameters.AddWithValue("@Id", recipe.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void DeleteRecipe(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipePlatform;Integrated Security=True;Connect Timeout=30";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Recipe WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    //public class Comment
    //{
    //    public int CommentId { get; set; }
    //    public int Id { get; set; }
    //    public string Text { get; set; }
    //    public DateTime PostDate { get; set; }
    //}
}
