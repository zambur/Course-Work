C_FILES := $(wildcard *.c)
TARGETS := ${C_FILES:.c=}

all: ${TARGETS}

%: %.c
	gcc -g -m32 -L.. -lmem -Xlinker -rpath=. -o $@ $<

clean:
	rm -rf ${TARGETS} *.o
