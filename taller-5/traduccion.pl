tiempo(presente).
tiempo(pasado).
tiempo(futuro).

persona(primera).
persona(segunda).
persona(tercera).

numero(singular).
numero(plural).

ser(presente, primera, singular, "am").
ser(presente, segunda, singular, "are").
ser(presente, tercera, singular, "is").
ser(presente, primera, plural, "are").
ser(presente, segunda, plural, "are").
ser(presente, tercera, plural, "are").

ser(pasado, primera, singular, "was").
ser(pasado, segunda, singular, "were").
ser(pasado, tercera, singular, "was").
ser(pasado, primera, plural, "were").
ser(pasado, segunda, plural, "were").
ser(pasado, tercera, plural, "were").

ser(futuro, primera, singular, "will be").
ser(futuro, segunda, singular, "will be").
ser(futuro, tercera, singular, "will be").
ser(futuro, primera, plural, "will be").
ser(futuro, segunda, plural, "will be").
ser(futuro, tercera, plural, "will be").

have(presente, primera, singular, "have").
have(presente, segunda, singular, "have").
have(presente, tercera, singular, "has").
have(presente, primera, plural, "have").
have(presente, segunda, plural, "have").
have(presente, tercera, plural, "have").

have(pasado, primera, singular, "had").
have(pasado, segunda, singular, "had").
have(pasado, tercera, singular, "had").
have(pasado, primera, plural, "had").
have(pasado, segunda, plural, "had").
have(pasado, tercera, plural, "had").

have(futuro, primera, singular, "have").
have(futuro, segunda, singular, "have").
have(futuro, tercera, singular, "have").
have(futuro, primera, plural, "have").
have(futuro, segunda, plural, "have").
have(futuro, tercera, plural, "have").

conjugar_verbo(Verbo, Tiempo, Persona, Numero, Conjugacion) :- 
              tiempo(Tiempo),
              persona(Persona),
              numero(Numero),
              (   
              	Verbo = "to be" ->
              	ser(Tiempo, Persona, Numero, R), Conjugacion = R;
              Verbo = "have" ->  
              have(Tiempo, Persona, Numero, H), Conjugacion = H;
              Conjugacion = Verbo
              ).