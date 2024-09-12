materiaCreditos(quimica, 3).
materiaCreditos(matematica, 3).
materiaCreditos(fisica, 2).

estudiante(juan, quimica).
estudiante(carlos, matematicas).
estudiante(maria, fisica).

creditosInscritos(Persona, Creditos):-
    estudiante(Persona, Materia),
    materiaCreditos(Materia, Creditos).