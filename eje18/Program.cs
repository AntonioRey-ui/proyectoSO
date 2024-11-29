//===Carlos Antonio Villaseñor Garcia  |  441641===
using System;
using System.Collections.Generic;

// muestra un sistema de cursos y estudiantes utiliza composicion
// para las relaciones entre la clase Curso y Estudiante donde un curso contiene
// varios estudiantes luego se  implementa una lista enlazada simple para almacenar 
// y mostrar los cursos agregados y sus estudiantes

class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Matricula { get; set; }

    public Estudiante(string nombre, int edad, string matricula)
    {
        Nombre=nombre;
        Edad=edad;
        Matricula=matricula;
    }
}

class Curso
{
    public string NombreCurso { get; set; }
    // Composicion- la clase Curso contiene una lista de objetos Estudiante
    public List<Estudiante> Estudiantes { get; private set; }

    public Curso(string nombreCurso)
    {
        NombreCurso=nombreCurso;
        Estudiantes=new List<Estudiante>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    public void MostrarEstudiantes()
    {
        foreach (var estudiante in Estudiantes)
        {
            Console.WriteLine($"nombre: {estudiante.Nombre}, edad: {estudiante.Edad}, matri8cula: {estudiante.Matricula}");
        }
    }
}

class NodoCurso
{
    public Curso Curso { get; set; }
    public NodoCurso Siguiente { get; set; }

    public NodoCurso(Curso curso)
    {
        Curso= curso;
        Siguiente= null;
    }
}

class ListaEnlazadaCursos
{
    private NodoCurso cabeza;

    public ListaEnlazadaCursos()
    {
        cabeza = null;
    }

    public void AgregarCurso(Curso curso)
    {
        NodoCurso nuevoNodo = new NodoCurso(curso);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
    }

    public void MostrarListaCursos()
    {
        NodoCurso actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"curso: {actual.Curso.NombreCurso}");
            actual.Curso.MostrarEstudiantes();
            actual = actual.Siguiente;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===Carlos Antonio Villaseñor Garcia  |  441641===");
        //crea una instancia de Curso y agregar estudiantes
        Curso cursoPython = new Curso("Python");
        cursoPython.AgregarEstudiante(new Estudiante("antonio", 21, "A1001"));
        cursoPython.AgregarEstudiante(new Estudiante("bruno", 22, "A1002"));
        cursoPython.AgregarEstudiante(new Estudiante("Carlos", 20, "A1003"));

        //prueba del uso independiente de un objeto de la clase
        Console.WriteLine("estudiantes en el curso independiente:");
        cursoPython.MostrarEstudiantes();

        //crear una lista enlazada de cursos y agrega cursos
        ListaEnlazadaCursos listaCursos = new ListaEnlazadaCursos();
        listaCursos.AgregarCurso(cursoPython);

        //agregar otro curso para demostrar el uso de la lista enlazada
        Curso cursoJavaScript = new Curso("UI UX");
        cursoJavaScript.AgregarEstudiante(new Estudiante("diana", 23, "B2001"));
        cursoJavaScript.AgregarEstudiante(new Estudiante("andrea", 24, "B2002"));
        listaCursos.AgregarCurso(cursoJavaScript);

        //mostrar la lista enlazada de cursos
        Console.WriteLine("\ncontenido de la lista enlazada de cursos:");
        listaCursos.MostrarListaCursos();
    }
}