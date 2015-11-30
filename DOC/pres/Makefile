NAME=pres

all:
#	vlna -v -f $(NAME).tex
	latex $(NAME).tex
	latex $(NAME).tex
	dvips $(NAME).dvi
	ps2pdf -sPAPERSIZE=a4 $(NAME).ps

clean:
	rm -f $(NAME).{aux,blg,dvi,log,ps,out,nav,snm,tocvrb,toc,vrb} *~

pack: 
	tar -zcf $(NAME)tar.gz Makefile pres.tex pic.eps

