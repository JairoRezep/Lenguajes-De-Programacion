import random

# Inicializar datos
num_sucursales = 25
sucursales = list(range(1, num_sucursales + 1))  # Sucursales 1 a 25
ventas = [random.randint(1000, 5000) for _ in range(num_sucursales)]  # Ventas aleatorias entre 1000 y 5000

# Calcular el promedio de ventas
promedio_ventas = sum(ventas) / num_sucursales

# Mostrar el promedio de ventas
print(f"Promedio de ventas: {promedio_ventas:.2f}")

# Mostrar las sucursales con ventas mayores al promedio
print("Sucursales con ventas mayores al promedio:")
for i in range(num_sucursales):
    if ventas[i] > promedio_ventas:
        print(f"Sucursal {sucursales[i]} con ventas de: {ventas[i]}")
