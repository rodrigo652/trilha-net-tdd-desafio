using NewTalents;

namespace TesteNewTalents;

public class UnitTest1
{
    public Calculadora construirClasse()
    {
        string data = "01/01/2023";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    [Theory]
    [InlineData(1 , 2 , 3)]
    [InlineData(4 , 5 , 9)]
    public void Somar_Valor1EValor2_RetornarResultado(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        
        int resultadoCalculo = calc.Somar(val1, val2);

        Assert.Equal(resultado, resultadoCalculo);
  
    }

    [Theory]
    [InlineData(3 , 2 , 1)]
    [InlineData(5 , 4 , 1)]
    public void Subtrair_Valor1EValor2_RetornarResultado(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        
        int resultadoCalculo = calc.Subtrair(val1, val2);

        Assert.Equal(resultado, resultadoCalculo);
  
    }

    [Theory]
    [InlineData(2 , 2 , 4)]
    [InlineData(4 , 4 , 16)]
    public void Multiplicar_Valor1EValor2_RetornarResultado(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        
        int resultadoCalculo = calc.Multiplicar(val1, val2);

        Assert.Equal(resultado, resultadoCalculo);
  
    }

    [Theory]
    [InlineData(2 , 2 , 1)]
    [InlineData(20 , 5 , 4)]
    public void Dividir_Valor1EValor2_RetornarResultado(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        
        int resultadoCalculo = calc.Dividir(val1, val2);

        Assert.Equal(resultado, resultadoCalculo);
  
    }

    [Fact]
    public void Dividir_PorZero_RetornarException()
    {
        // Given
        Calculadora calc = construirClasse();
        // When
        int val1 = 3;
        // Then
        Assert.Throws<DivideByZeroException>( 
                () => calc.Dividir(val1 , 0));

    }

    [Fact]
    public void Historico_RetornarOsTresUltimosCalculos()
    {
        // Given
        Calculadora calc = construirClasse();
        // When
        calc.Somar(1,2);
        calc.Somar(2,2);
        calc.Somar(3,2);
        calc.Somar(4,2);

        var lista = calc.Historico();

        // Then
        Assert.NotEmpty(lista);
        Assert.Equal(3 , lista.Count);

    }
}