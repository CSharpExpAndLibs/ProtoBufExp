COMPILER_PREFIX :=
CC := $(COMPILER_PREFIX)gcc
CXX := $(COMPILER_PREFIX)g++
RM := rm -rf

#---------------------------------------------------------------------#
SRCDIR := ..
SRCS := dllmain.cpp
OBJS := $(SRCS:.cpp=.o)

#---------------------------------------------------------------------#
CPPFLAGS := -I$(SRCDIR) -D_LINUX_BUILD_
CFLAGS := -g3 -O2 -Wall
CXXFLAGS := $(CFLAGS)
LDFLAGS :=

#---------------------------------------------------------------------#
SO_BASE := libPointarAccessSample.so
#SO_MAJOR := .0
#SO_MINOR := .1
SO_NAME := $(SO_BASE)$(SO_MAJOR)
TARGET := $(SO_NAME)$(SO_MINOR)

#---------------------------------------------------------------------#
all: $(TARGET)

$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS) -shared -o $@ $^ -Wl,-soname,$(SO_NAME) $(LDFLAGS)

%.o: $(SRCDIR)/%.cpp
	$(CXX) $(CPPFLAGS) $(CXXFLAGS) -MMD -fPIC -c $<

clean:
	$(RM) *~ $(OBJS) $(SO_BASE)*

realclean: clean
	$(RM) $(OBJS:.o=.d)

.PHONY: all clean realclean

#---------------------------------------------------------------------#
-include $(OBJS:.o=.d)
