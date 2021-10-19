

#include <iostream>
#include <cstdlib>
using namespace std;
int main()
{
	system("chcp 1251>nul");

	const double kmInMile = 1.609344;

	double distMile, distKm;

	cout << "Въведете разстоянието в мили: ";
	cin >> distMile;
	distKm = distMile * kmInMile;

	cout << "Разстояние (в км): " << distKm << endl;

	system("pause>nul");
		return 0;
}

