using System;
using System.Collections.Generic;
using System.Linq;

namespace KnUsaPresident.Models
{
    public class President
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public string Party { get; set; }

        public string PhotoFile { get; set; }

        private static readonly Lazy<IList<President>> _presidentList = new Lazy<IList<President>>(CreatePresidentList);

        public IList<President> PresidentList
        {
            get { return _presidentList.Value; }
        }

        private static IList<President> CreatePresidentList()
        {
            var l = new List<President>
            {
                new President(1, "George Washington (1732-1799)", "Federalist", "1789-1797", "gwashington"),
                new President(2, "John Adams (1735-1826)", "Federalist", "1797-1801", "jadams"),
                new President(3, "Thomas Jefferson (1743-1826)", "Democratic-Republican", "1801-1809", "tjefferson"),
                new President(4, "James Madison (1751-1836)", "Democratic-Republican", "1809-1817", "jmadison"),
                new President(5, "James Monroe (1758-1831)", "Democratic-Republican", "1817-1825", "jmonroe"),
                new President(6, "John Quincy Adams (1767-1848)", "Democratic-Republican", "1825-1829", "jqadams"),
                new President(7, "Andrew Jackson (1767-1845)", "Democrat", "1829-1837", "ajackson"),
                new President(8, "Martin van Buren (1782-1862)", "Democrat", "1837-1841", "mburen"),
                new President(9, "William H. Harrison (1773-1841)", "Whig", "1841", "wharrison"),
                new President(10, "John Tyler (1790-1862)", "Whig", "1841-1845", "jtyler"),
                new President(11, "James K. Polk (1795-1849)", "Democrat", "1845-1849", "jpolk"),
                new President(12, "Zachary Taylor (1784-1850)", "Whig", "1849-1850", "ztaylor"),
                new President(13, "Millard Fillmore (1800-1874)", "Whig", "1850-1853", "mfillmore"),
                new President(14, "Franklin Pierce (1804-1869)", "Democrat ", "1853-1857", "fpierce"),
                new President(15, "James Buchanan (1791-1868)", "Democrat", "1857-1861", "jbuchanan"),
                new President(16, "Abraham Lincoln (1809-1865)", "Republican", "1861-1865", "alincoln"),
                new President(17, "Andrew Johnson (1808-1875)", "National Union", "1865-1869", "ajohnson"),
                new President(18, "Ulysses S, Grant (1822-1885)", "Republican", "1869-1877", "ugrant"),
                new President(19, "Rutherford Hayes (1822-1893)", "Republican", "1877-1881", "rhayes"),
                new President(20, "James Garfield (1831-1881)", "Republican", "1881", "jgarfield"),
                new President(21, "Chester Arthur (1829-1886)", "Republican", "1881-1885", "carthur"),
                new President(22, "Grover Cleveland (1837-1908)", "Democrat", "1885-1889", "gcleveland"),
                new President(23, "Benjamin Harrison (1833-1901)", "Republican", "1889-1893", "bharrison"),
                new President(24, "Grover Cleveland (1837-1908)", "Democrat ", "1893-1897", "gcleveland"),
                new President(25, "William McKinley (1843-1901)", "Republican", "1897-1901", "wmckinley"),
                new President(26, "Theodore Roosevelt (1858-1919)", "Republican", "1901-1909", "troosevelt"),
                new President(27, "William Taft (1857-1930)", "Republican", "1909-1913", "wtaft"),
                new President(28, "Woodrow Wilson (1856-1924)", "Democrat", "1913-1921", "wwilson"),
                new President(29, "Warren Harding (1865-1923)", "Republican", "1921-1923", "wharding"),
                new President(30, "Calvin Coolidge (1872-1933)", "Republican", "1923-1929", "ccoolidge"),
                new President(31, "Herbert C, Hoover (1874-1964)", "Republican", "1929-1933", "hhoover"),
                new President(32, "Franklin Delano Roosevelt (1882-1945)", "Democrat", "1933-1945", "froosevelt"),
                new President(33, "Harry S Truman (1884-1972)", "Democrat", "1945-1953", "htruman"),
                new President(34, "Dwight David Eisenhower (1890-1969)", "Republican", "1953-1961", "deisenhower"),
                new President(35, "John Fitzgerald Kennedy (1917-1963)", "Democrat", "1961-1963", "jkennedy"),
                new President(36, "Lyndon Baines Johnson (1908-1973)", "Democrat", "1963-1969", "ljohnson"),
                new President(37, "Richard Milhous Nixon (1913-1994)", "Republican", "1969-1974", "rnixon"),
                new President(38, "Gerald R. Ford (1913- 2006)", "Republican", "1974-1977", "gford"),
                new President(39, "James (Jimmy) Earl Carter, Jr. (1924- )", "Democrat", "1977-1981", "jcarter"),
                new President(40, "Ronald Wilson Reagan (1911- 2004)", "Republican", "  1981-1989", "rreagan"),
                new President(41, "George H. W. Bush (1924- )", "Republican", "1989-1993", "ghbush"),
                new President(42, "William (Bill) Jefferson Clinton (1946- )", "Democrat", "1993-2001", "wclinton"),
                new President(43, "George W. Bush (1946- )", "Republican", "2001-2009", "gwbush"),
                new President(44, "Barack Obama (1961- )", "Democrat", "2009-2017", "bobama")
            };

            return l;
        }


        private string _cdn = "http://res.cloudinary.com/dteumtg3s/image/upload/v1445549298/";
        public President(int id, string name, string party, string term,  string photo)
        {
            Id = id;
            Name = name;
            Term = term;
            Party = party;
            PhotoFile = string.Format("{0}{1}.{2}", _cdn, photo, "jpg");
        }

        public President()
        {
            Id = 0;
            Name = "";
            Term = "";
            Party = "";
            PhotoFile ="";
        }
    }
}
