all: xpokor32

xpokor32: 
	make -C DOC/
	cp DOC/doc.pdf .
	make -C DOC/pres/
	cp DOC/pres/pres.pdf .
	zip -r xpokor32.zip BIO.Project.FingerVeinRecognition/ doc.pdf pres.pdf team.txt

clean:
	rm -f doc.pdf pres.pdf xpokor32.zip

