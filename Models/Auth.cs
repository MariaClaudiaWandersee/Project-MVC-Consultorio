namespace Models
{
    public class Auth
    {
        public static Paciente Paciente;
        public static Dentista Dentista;

        public static bool isLogged;

        public static void Login(
            string Email,
            string Senha
        )
        {
            Paciente paciente = Paciente.GetPacientes()
                .Find(Paciente => Paciente.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Paciente.Senha));

            if (paciente != null)
            {
                System.Console.WriteLine(paciente.Senha);
                isLogged = true;
                Paciente = paciente;
                Dentista = null;
            }
            else
            {
                Dentista dentista = Dentista.GetDentistas()
                    .Find(Dentista => Dentista.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Dentista.Senha));
                System.Console.WriteLine(dentista.Senha);
                if (dentista != null)
                {
                    isLogged = true;
                    Dentista = dentista;
                    Paciente = null;
                }
                else
                {
                    Logout();
                    throw new System.Exception("Login inválido");
                }
            }
        }

        public static void Logout()
        {
            isLogged = false;
            Dentista = null;
            Paciente = null;
        }
    }
}
