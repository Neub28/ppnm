Out.txt : main.exe
	mono main.exe > Out.txt
sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs
main.exe : main.cs sfuns.dll
	mcs main.cs -reference:sfuns.dll -out:main.exe

.PHONY : 
clean : 
	rm -f *.txt *.dll *.exe
