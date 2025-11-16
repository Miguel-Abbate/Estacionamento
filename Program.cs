string tam;
int tempo;
string valet;
string lavagem;
double permanencia;
double vperma = 0.0;
double vvalet = 0.0;
double vlavagem = 0.0;
double vtotal = 0.0;
bool diaria = false;
const double PRIMEIRA_HORA = 20.00;
const double HORA_ADICIONAL_P = 10.00;
const double HORA_ADICIONAL_G = 20.00;
const double TARIFA_DIARIA_P = 50.00;
const double TARIFA_DIARIA_G = 80.00;
const double PERCENTUAL_VALET = 0.20;
const double PRECO_LAVAGEM_P = 50.00;
const double PRECO_LAVAGEM_G = 100.00;
const int LIMITE_MINUTOS_DIARIA = 299;
const int LIMITE_MAXIMO_MINUTOS = 720; 
const int TEMPO_TOLERANCIA_MINUTOS = 5; 
Console.Clear();
Console.WriteLine(" ----------------- *** ESTACIONAMENTO *** -----------------");
while (true)
{
    Console.Write("Tamanho do veículo (P/G).....: ");
    tam = Console.ReadLine().ToUpper();
    if (tam == "P" || tam == "G") break;
    Console.WriteLine("ERRO: Por favor, insira um valor válido ('p' ou 'g').");
}
while (true)
{
    Console.Write("Tempo de permanência (min)...: ");
    if (int.TryParse(Console.ReadLine(), out tempo))
    {
        if (tempo >= 0 && tempo <= LIMITE_MAXIMO_MINUTOS) break;
        Console.WriteLine($"ERRO: O tempo deve ser um valor entre 0 e {LIMITE_MAXIMO_MINUTOS} minutos (12h).");
    }
    else
    {
        Console.WriteLine("ERRO: Por favor, insira um número inteiro válido.");
    }
}
while (true)
{
    Console.Write("Serviço de valet (S/N).......: ");
    valet = Console.ReadLine().ToUpper();
    if (valet == "S" || valet == "N") break;
    Console.WriteLine("ERRO: Por favor, insira um valor válido ('s' ou 'n').");
}
while (true)
{
    Console.Write("Serviço de lavagem (S/N).....: ");
    lavagem = Console.ReadLine().ToUpper();
    if (lavagem == "S" || lavagem == "N") break;
    Console.WriteLine("ERRO: Por favor, insira um valor válido ('s' ou 'n').");
}
if (tempo <= TEMPO_TOLERANCIA_MINUTOS)
{
    permanencia = 0;
}
else if (tempo > LIMITE_MINUTOS_DIARIA)
{
    
    diaria = true;
    permanencia = 1; 
}
else
{
    permanencia = Math.Floor(((double)tempo + 59.0) / 60.0);
    }


if (permanencia > 0)
{
    if (tam == "P")
    {
        if (diaria)
        {
            vperma = TARIFA_DIARIA_P;
        }
        else
        {
                        vperma = PRIMEIRA_HORA + ((permanencia - 1) * HORA_ADICIONAL_P);
        }
    }
    else 
    {
        if (diaria)
        {
            vperma = TARIFA_DIARIA_G;
        }
        else
        {
            vperma = PRIMEIRA_HORA + ((permanencia - 1) * HORA_ADICIONAL_G);
        }
    }
}
if (valet == "S")
{
        vvalet = vperma * PERCENTUAL_VALET;
}
if (lavagem == "S")
{
        vlavagem = (tam == "P") ? PRECO_LAVAGEM_P : PRECO_LAVAGEM_G;
}
vtotal = vperma + vvalet + vlavagem;

Console.WriteLine("\n--- RESUMO DA COBRANÇA ---");
Console.WriteLine($"Tipo de Veículo.: {(tam == "P" ? "Pequeno" : "Grande")}");
Console.WriteLine($"Tempo Total.....: {tempo} minutos");
Console.WriteLine($"Horas Cobradas..: {(diaria ? "DIÁRIA" : $"{permanencia} horas")}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Estacionamento..: {vperma,12:R$ #0.00}");
Console.WriteLine($"Valet...........: {vvalet,12:R$ #0.00}");
Console.WriteLine($"Lavagem.........: {vlavagem,12:R$ #0.00}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Total...........: {vtotal,12:R$ #0.00}");

Console.Write("\nPressione qualquer tecla para sair...");
Console.ReadKey();