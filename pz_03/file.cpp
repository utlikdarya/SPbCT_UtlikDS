#include <iostream>
#include <string>
#include <iostream>
#include <vector>
 
using namespace std;
 
const int FIRST_SYMBOL = ' '; // первый символ
const int SYMBOL_NUMBER = 95; // для простоты кодируем только английский алфавит 
 
void GammaCoding( string &input, string &gamma, string &result )
{
  result.clear();
  for( string::iterator i=input.begin(), j=gamma.begin(); i<input.end(); i++, j++ )
  {
    if(j==gamma.end()) j=gamma.begin();
    int Ti = *i - FIRST_SYMBOL;
    int Gi = *j - FIRST_SYMBOL;
    result.push_back(FIRST_SYMBOL+(Ti+Gi)%SYMBOL_NUMBER);
  }
}
 
void GammaDecoding( string &input, string &gamma, string &result )
{
  result.clear();
  for( string::iterator i=input.begin(), j=gamma.begin(); i<input.end(); i++, j++ )
  {
    if(j==gamma.end()) j=gamma.begin();
    int Ci = *i - FIRST_SYMBOL;
    int Gi = *j - FIRST_SYMBOL;
    result.push_back(FIRST_SYMBOL+(Ci-Gi+SYMBOL_NUMBER)%SYMBOL_NUMBER);
  }
}
 
int main()
{
    setlocale(LC_ALL, "rus");
    string str1, gamma, rez;
    string str1_v, gamma_v, rez_v;
    cout << "Введите исходное сообщение: ";
    cin >> str1;
    cout << "Введите гамму: ";
    cin >> gamma;
 
    GammaCoding( str1, gamma, rez );
    cout << "Зашифрованное сообщение: ";
    cout << rez << endl;
  
    cout << "Введите зашифрованное сообщение: ";
    cin >> rez;
 
    GammaDecoding( rez, gamma, str1 );
    cout << "Исходное сообщение: ";
    cout << str1 << endl;
 
    system("pause");
    return 0;
}
