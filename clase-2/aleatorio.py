import random

# Inicializar los contadores
pares = 0
impares = 0

# Generar 500 valores aleatorios entre 50 y 100
for _ in range(500):
    num = random.randint(50, 100)  # Genera un número entre 50 y 100
    if num % 2 == 0:
        pares += 1
    else:
        impares += 1

# Mostrar los resultados
print(f"Cantidad de números pares: {pares}")
print(f"Cantidad de números impares: {impares}")
