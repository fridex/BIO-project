# Makefile for BIO project
# Fridolin Pokorny <xpokor32@stud.fit.vutbr.cz>
# 2015

NAME = doc
PACKNAME = doc

.PHONY: pack clean

all: doc

doc:
	#vlna -v KkSsVvZzOoUuAIai $@.tex
	latex $@.tex
	latex $@.tex
	dvips -t a4 $@.dvi
	ps2pdf $@.ps

clean:
	rm -f ${NAME}.{pdf,ps,dvi,log,aux,out,toc} $(PACKNAME).tar.gz *~

pack:
	tar -zcf $(PACKNAME).tar.gz sen-proj.tex Makefile

