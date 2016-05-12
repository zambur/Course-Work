## Scalable Web Crawler

In this program, I developed a web crawler. To simplify this project, the crawler parses web pages in a simplified format (not HTML). In order to achieve high performance and utilize the CPU, the crawler uses multiple threads. My crawler has two groups (or pools) of threads. The downloaders are responsible for fetching new pages from the Internet. The parsers will scan the downloaded pages for new links. When a downloader fetches a new page, it creates more work for a parser. Similarly, when parser finds a new link, it creates more work for a downloader. The downloaders and the parsers will send work to each other via two queues. A bitmap keeps track of what webpages have already been visited making sure to not visit any pages twice as well as to know when all webpages have been visited so the program can safely end.

These routines are made in a shared library named "libcrawler.so". Placing the routines in a shared library instead of a simple object file makes it easier for other programmers to link with your code. This way different applications that need to do web crawling may use it. Also, my library uses callbacks to provide the most flexibility to users.




