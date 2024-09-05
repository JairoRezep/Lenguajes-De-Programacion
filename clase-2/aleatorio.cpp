#include <iostream>
#include <cstdlib>
#include <ctime>

int main() {
    // Inicializar el generador de números aleatorios
    std::srand(std::time(0));

    int pares = 0;
    int impares = 0;

    // Generar 500 valores aleatorios entre 50 y 100
    for (int i = 0; i < 500; ++i) {
        int num = std::rand() % 51 + 50;  // Genera un número entre 50 y 100
        if (num % 2 == 0) {
            pares++;
        } else {
            impares++;
        }
    }

    // Mostrar los resultados
    std::cout << "Cantidad de números pares: " << pares << std::endl;
    std::cout << "Cantidad de números impares: " << impares << std::endl;

    return 0;
}
