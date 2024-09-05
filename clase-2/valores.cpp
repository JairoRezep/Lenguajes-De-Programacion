#include <iostream>

int main(){
	int sum = 0;
	int num;
	for (int i = 0; i < 10; i ++){
		std::cin >> num;
		sum += num;			
	}
	float promedio = sum / 10;
	std:: cout << "La suma es: " << sum << std::endl;
	std::cout << "El promedio es: " << promedio << std::endl;
	return 0;
}
