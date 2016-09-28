.PHONY: clean

build:
	fsharpc code2art.fs
	chmod +x code2art.exe

rebuild: clean build

clean:
	rm -f code2art.exe
