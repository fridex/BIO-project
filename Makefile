all: xpokor32

xpokor32: 
	make -C DOC/
	cp DOC/doc.pdf .
	zip -r xpokor32.zip BIO.Project.FingerVeinRecognition/ doc.pdf team.txt

clean:
	rm -f doc.pdf xpokor32.zip

