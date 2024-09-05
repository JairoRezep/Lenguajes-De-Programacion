#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>

int main() {
    const int num_sucursales = 25;
    int sucursales[num_sucursales];
    int ventas[num_sucursales];
    double suma_ventas = 0.0;
    
    // Inicializar el generador de números aleatorios
    std::srand(std::time(0));
    
    // Generar ventas aleatorias para cada sucursal (entre 1000 y 5000)
    for (int i = 0; i < num_sucursales; ++i) {
        sucursales[i] = i + 1;  // Número de sucursal
        ventas[i] = std::rand() % 4001 + 1000;  // Ventas entre 1000 y 5000
        suma_ventas += ventas[i];
    }
    
    // Calcular el promedio de ventas
    double promedio_ventas = suma_ventas / num_sucursales;
    
    // Mostrar el promedio de ventas
    std::cout << "Promedio de ventas: " << promedio_ventas << std::endl;
    
    // Mostrar las sucursales con ventas mayores al promedio
    std::cout << "Sucursales con ventas mayores al promedio: " << std::endl;
    for (int i = 0; i < num_sucursales; ++i) {
        if (ventas[i] > promedio_ventas) {
            std::cout << "Sucursal " << sucursales[i] << " con ventas de: " << ventas[i] << std::endl;
        }
    }
    
    return 0;
}
