using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Logic
    {
        public MovieVM ConvertMovieDmToVm(MovieDM movie)
        {
            MovieVM movieVm = new MovieVM();
            if (movie != null)
            {
                GenreDAO dao = new GenreDAO();
                movieVm.id = movie.id;
                movieVm.genre = dao.GetGenre(movie.genreId).ToString();
                movieVm.title = movie.title;
                movieVm.releaseDate = movie.releaseDate;
            }
            return movieVm;
        }
        public UserVM ConvertUserDmToVm(UserDM user)
        {
            UserVM userVm = new UserVM();
            if (user != null)
            {
                userVm.id = user.id;
                userVm.lastName = GetPerson(GetPersonAddress(user.personAddressId).personId).lastName;
                userVm.firstName = GetPerson(GetPersonAddress(user.personAddressId).personId).firstName;
                userVm.email = GetPerson(GetPersonAddress(user.personAddressId).personId).email;
                userVm.street = GetAddress(GetPersonAddress(user.personAddressId).addressId).street;
                userVm.city = GetAddress(GetPersonAddress(user.personAddressId).addressId).city;
                userVm.state = GetAddress(GetPersonAddress(user.personAddressId).addressId).state;
                userVm.zip = GetAddress(GetPersonAddress(user.personAddressId).addressId).zip;
                userVm.addressType = GetType(GetPersonAddress(user.personAddressId).typeId);
                userVm.number = GetPhone(GetPersonPhone(user.personPhoneId).phoneId);
                userVm.phoneType = GetType(GetPersonPhone(user.personPhoneId).typeId);
            }
            return userVm;
        }
        public AccountVM ConvertAccountDmToVm(AccountDM account)
        {
            AccountVM accountVm = new AccountVM();
            if (account != null)
            {
                accountVm.id = account.id;
                accountVm.lastName = GetPerson(GetPersonAddress(GetUser(account.userId).personAddressId).personId).lastName;
                accountVm.firstName = GetPerson(GetPersonAddress(GetUser(account.userId).personAddressId).personId).firstName;
                accountVm.email = GetPerson(GetPersonAddress(GetUser(account.userId).personAddressId).personId).email;
                accountVm.street = GetAddress(GetPersonAddress(GetUser(account.userId).personAddressId).addressId).street;
                accountVm.city = GetAddress(GetPersonAddress(GetUser(account.userId).personAddressId).addressId).city;
                accountVm.state = GetAddress(GetPersonAddress(GetUser(account.userId).personAddressId).addressId).state;
                accountVm.zip = GetAddress(GetPersonAddress(GetUser(account.userId).personAddressId).addressId).zip;
                accountVm.addressType = GetType(GetPersonAddress(GetUser(account.userId).personAddressId).typeId);
                accountVm.number = GetPhone(GetPersonPhone(GetUser(account.userId).personPhoneId).phoneId);
                accountVm.phoneType = GetType(GetPersonPhone(GetUser(account.userId).personPhoneId).typeId);
                accountVm.title = GetMovie(account.movieId).title;
                accountVm.releaseDate = GetMovie(account.movieId).releaseDate;
                accountVm.genre = GetGenre(GetMovie(account.movieId).genreId);
            }
            return accountVm;
        }
        public string GetGenre(int id)
        {
            GenreDAO dao = new GenreDAO();
            return dao.GetGenre(id);
        }
        public MovieDM GetMovie(int id)
        {
            MovieDAO dao = new MovieDAO();
            return dao.GetMovieById(id);
        }
        public UserDM GetUser(int id)
        {
            UserDAO dao = new UserDAO();
            return dao.GetUserById(id);
        }
        public string GetType(int id)
        {
            TypeDAO dao = new TypeDAO();
            return dao.GetType(id);
        }
        public string GetPhone(int id)
        {
            PhoneDAO dao = new PhoneDAO();
            return dao.GetPhone(id);
        }
        public AddressDM GetAddress(int id)
        {
            AddressDAO dao = new AddressDAO();
            return dao.GetAddress(id);
        }
        public PersonDM GetPerson(int id)
        {
            PersonDAO dao = new PersonDAO();
            return dao.GetPerson(id);
        }
        public PersonPhoneDM GetPersonPhone(int id)
        {
            PersonPhoneDAO dao = new PersonPhoneDAO();
            return dao.GetPersonPhone(id);
        }
        public PersonAddressDM GetPersonAddress(int id)
        {
            PersonAddressDAO dao = new PersonAddressDAO();
            return dao.GetPersonAddress(id);
        }
        public MovieDM ConvertMovieVmToDm(MovieVM movieVm)
        {
            MovieDM movieDm = new MovieDM();
            if (movieVm != null)
            {
                GenreDAO dao = new GenreDAO();
                movieDm.title = movieVm.title;
                movieDm.releaseDate = movieVm.releaseDate;
                movieDm.genreId = dao.GetGenreId(movieVm.genre);
                bool x = dao.DoesGenreExist(dao.GetGenreId(movieVm.genre));
                if (x == false)
                {
                    dao.CreateGenre(movieVm.genre);
                    movieDm.genreId = dao.GetGenreId(movieVm.genre);
                }
                else
                {
                    movieDm.genreId = dao.GetGenreId(movieVm.genre);
                }
            }
            return movieDm;
        }
        public UserDM ConvertUserVmToDm(UserVM userVm)
        {
            UserDM userDm = new UserDM();
            if (userVm != null)
            {
                SetPersonAddressId(userVm, userDm);
                SetPersonPhoneId(userVm, userDm);
            }
            return userDm;
        }
        public AccountDM ConvertAccountVmToDm(AccountVM accountVm)
        {
            AccountDM accountDm = new AccountDM();
            if (accountVm != null)
            {
                accountDm.userId = SetUserId(accountVm, accountDm);
                accountDm.movieId = SetMovieId(accountVm, accountDm);
            }
            return accountDm;
        }
        public int GetMovieId(string title, DateTime releaseDate, string genre)
        {
            MovieDAO dao = new MovieDAO();
            MovieDM movie = dao.GetMovie(title, releaseDate, genre);
            if (movie == null)
            {
                CreateMovie(title, releaseDate, genre);
                movie = dao.GetMovie(title, releaseDate, genre); 
            }
            return movie.id;
        }
        public int SetMovieId(AccountVM accountVm, AccountDM accountDm)
        {
            MovieDAO dao = new MovieDAO();
            bool x = dao.DoesMovieExist(GetMovieId(accountVm.title, accountVm.releaseDate, accountVm.genre));
            if (x == false)
            {
                CreateMovie(accountVm.title, accountVm.releaseDate, accountVm.genre);
                accountDm.movieId = GetMovieId(accountVm.title, accountVm.releaseDate, accountVm.genre);
            }
            else
            {
                accountDm.movieId = GetMovieId(accountVm.title, accountVm.releaseDate, accountVm.genre);
            }
            return accountDm.movieId;
        }
        private void SetPersonPhoneId(UserVM userVm, UserDM userDm)
        {
            bool w = DoesPersonPhoneExist(GetPersonPhoneId(SetPersonId(userVm.lastName, userVm.firstName, userVm.email),
            SetPhoneId(userVm.number), SetTypeId(userVm.phoneType)));
            if (w == false)
            {
                PersonPhoneDM phone = CreatePersonPhone(userVm.lastName, userVm.firstName, userVm.email,
                    userVm.number, userVm.phoneType);
                userDm.personPhoneId = GetPersonPhoneId(phone.personId, phone.phoneId, phone.typeId);
            }
            else
            {
                userDm.personPhoneId = GetPersonPhoneId(SetPersonId(userVm.lastName, userVm.firstName, userVm.email),
                        SetPhoneId(userVm.number), SetTypeId(userVm.phoneType));
            }
        }
        private int SetUserDmPersonPhoneId(AccountVM accountVm, UserDM userDm)
        {
            bool w = DoesPersonPhoneExist(GetPersonPhoneId(SetPersonId(accountVm.lastName, accountVm.firstName, accountVm.email),
            SetPhoneId(accountVm.number), SetTypeId(accountVm.phoneType)));
            if (w == false)
            {
                PersonPhoneDM phone = CreatePersonPhone(accountVm.lastName, accountVm.firstName, accountVm.email,
                    accountVm.number, accountVm.phoneType);
                userDm.personPhoneId = GetPersonPhoneId(phone.personId, phone.phoneId, phone.typeId);
            }
            else
            {
                userDm.personPhoneId = GetPersonPhoneId(SetPersonId(accountVm.lastName, accountVm.firstName, accountVm.email),
                        SetPhoneId(accountVm.number), SetTypeId(accountVm.phoneType));
            }
            return userDm.personPhoneId;
        }
        public int SetUserId(AccountVM accountVm, AccountDM accountDm)
        {
            UserDM user = new UserDM();
            bool x = DoesUserExist(GetUserId((SetUserDmPersonAddressId(accountVm, user)), 
                SetUserDmPersonPhoneId(accountVm, user)));
            if (x == false)
            {
                CreateUser((SetUserDmPersonAddressId(accountVm, user)),
                    SetUserDmPersonPhoneId(accountVm, user));
                accountDm.userId = GetUserId((SetUserDmPersonAddressId(accountVm, user)),
                    SetUserDmPersonPhoneId(accountVm, user));
            }
            else
            {
                accountDm.userId = GetUserId((SetUserDmPersonAddressId(accountVm, user)),
                    SetUserDmPersonPhoneId(accountVm, user));
            }
            return accountDm.userId;
        }
        public int GetUserId(int personAddressId, int personPhoneId)
        {
            UserDAO dao = new UserDAO();
            UserDM user = dao.GetUser(personAddressId, personPhoneId);
            if (user == null)
            {
                CreateUser(personAddressId, personPhoneId);
                user = dao.GetUser(personAddressId, personPhoneId);
            }
            return user.id;
        }
        public bool DoesUserExist(int userId)
        {
            UserDAO dao = new UserDAO();
            return dao.DoesUserExist(userId);
        }
        public int GetPhoneId(string number)
        {
            PhoneDAO dao = new PhoneDAO();
            return dao.GetPhoneId(number);
        }
        private int SetPhoneId(string number)
        {
            int y = 0;
            bool x = DoesPhoneExist(GetPhoneId(number));
            if (x == false)
            {
                CreatePhone(number);
                y = GetPhoneId(number);
            }
            else
            {
                y = GetPhoneId(number);
            }
            return y;
        }
        public bool DoesPersonPhoneExist(int id)
        {
            PersonPhoneDAO dao = new PersonPhoneDAO();
            return dao.DoesPersonPhoneExist(id);
        }
        private int SetPersonAddressId(UserVM userVm, UserDM userDm)
        {
            bool w = DoesPersonAddressExist(GetPersonAddressId(SetPersonId(userVm.lastName, userVm.firstName, userVm.email),
                SetAddressId(userVm.street, userVm.city, userVm.state, userVm.zip), SetTypeId(userVm.addressType)));
            if (w == false)
            {
                PersonAddressDM address = CreatePersonAddress(userVm.lastName, userVm.firstName, userVm.email,
                    userVm.street, userVm.city, userVm.state, userVm.zip, userVm.addressType);
                userDm.personAddressId = GetPersonAddressId(address.personId, address.addressId, address.typeId);
            }
            else
            {
                userDm.personAddressId = GetPersonAddressId(SetPersonId(userVm.lastName, userVm.firstName, userVm.email),
                        SetAddressId(userVm.street, userVm.city, userVm.state, userVm.zip), SetTypeId(userVm.addressType));
            }
            return userDm.personAddressId;
        }
        public int SetUserDmPersonAddressId(AccountVM accountVm, UserDM userDm)
        {
            bool w = DoesPersonAddressExist(GetPersonAddressId(SetPersonId(accountVm.lastName, accountVm.firstName, accountVm.email),
                SetAddressId(accountVm.street, accountVm.city, accountVm.state, accountVm.zip), SetTypeId(accountVm.addressType)));
            if (w == false)
            {
                PersonAddressDM address = CreatePersonAddress(accountVm.lastName, accountVm.firstName, accountVm.email,
                    accountVm.street, accountVm.city, accountVm.state, accountVm.zip, accountVm.addressType);
                userDm.personAddressId = GetPersonAddressId(address.personId, address.addressId, address.typeId);
            }
            else
            {
                userDm.personAddressId = GetPersonAddressId(SetPersonId(accountVm.lastName, accountVm.firstName, accountVm.email),
                        SetAddressId(accountVm.street, accountVm.city, accountVm.state, accountVm.zip), SetTypeId(accountVm.addressType));
            }
            return userDm.personAddressId;
        }
        public int GetTypeId(string type)
        {
            TypeDAO dao = new TypeDAO();
            return dao.GetTypeId(type);
        }
        private int SetTypeId(string type)
        {
            int x = 0;
            bool z = DoesTypeExist(GetTypeId(type));
            if (z == false)
            {
                CreateType(type);
                x = GetTypeId(type);
            }
            else
            {
                x = GetTypeId(type);
            }
            return x;
        }
        public int GetAddressId(string street, string city, string state, string zip)
        {
            AddressDAO dao = new AddressDAO();
            return dao.GetAddressId(street, city, state, zip);
        }
        private int SetAddressId(string street, string city, string state, string zip)
        {
            int x = 0;
            bool y = DoesAddressExist(GetAddressId(street, city, state, zip));
            if (y == false)
            {
                CreateAddress(street, city, state, zip);
                x = GetAddressId(street, city, state, zip);
            }
            else
            {
                x = GetAddressId(street, city, state, zip);
            }
            return x;
        }
        public int GetPersonId(string lastName, string firstName, string email)
        {
            PersonDAO dao = new PersonDAO();
            return dao.GetPersonId(lastName, firstName, email);
        }
        private int SetPersonId(string lastName, string firstName, string email)
        {
            int y = 0;
            bool x = DoesPersonExist(GetPersonId(lastName, firstName, email));
            if (x == false)
            {
                CreatePerson(lastName, firstName, email);
                y = GetPersonId(lastName, firstName, email);
            }
            else
            {
                y = GetPersonId(lastName, firstName, email);
            }
            return y;
        }
        public bool DoesPersonAddressExist(int id)
        {
            PersonAddressDAO dao = new PersonAddressDAO();
            return dao.DoesPersonAddressExist(id);
        }
        private static bool DoesPersonExist(UserVM userVm, PersonDAO personDao)
        {
            bool a = personDao.DoesPersonExist(personDao.GetPersonId(userVm.lastName, userVm.firstName, userVm.email));
            return a;
        }
        public MovieVM CreateMovie(string title, DateTime releaseDate, string genre)
        {
            MovieDAO dao = new MovieDAO();
            MovieVM movie = new MovieVM();
            movie.title = title;
            movie.releaseDate = releaseDate;
            movie.genre = genre;
            MovieDM movieDm = ConvertMovieVmToDm(movie);
            dao.CreateMovie(movieDm.title, movieDm.releaseDate, movie.genre);
            return movie;
        }
        public PersonDM CreatePerson(string lastName, string firstName, string email)
        {
            PersonDM person = new PersonDM();
            person.lastName = lastName;
            person.firstName = firstName;
            person.email = email;
            PersonDAO dao = new PersonDAO();
            dao.CreatePerson(lastName, firstName, email);
            return person;
        }
        public void CreateUser(int personAddressId, int personPhoneId)
        {
            UserDAO dao = new UserDAO();
            dao.CreateUser(personAddressId, personPhoneId);
        }
        public void CreateAccountDB(AccountDM account)
        {
            AccountDAO dao = new AccountDAO();
            dao.CreateAccount(account);
        }
        public AccountVM CreateAccount(string lastName, string firstName, string email,
            string street, string city, string state, string zip, string addressType,
            string number, string phoneType, string title, DateTime releaseDate, string genre)
        {
            AccountVM account = new AccountVM();
            account.lastName = lastName;
            account.firstName = firstName;
            account.email = email;
            account.street = street;
            account.city = city;
            account.state = state;
            account.zip = zip;
            account.addressType = addressType;
            account.number = number;
            account.phoneType = phoneType;
            account.title = title;
            account.releaseDate = releaseDate;
            account.genre = genre;
            AccountDM accountDm = ConvertAccountVmToDm(account);
            CreateAccountDB(accountDm);
            return account;
        }
        public UserVM CreateUserVM(string lastName, string firstName, string email,
            string street, string city, string state, string zip, string addressType,
            string number, string phoneType)
        {
            UserVM user = new UserVM();
            user.lastName = lastName;
            user.firstName = firstName;
            user.email = email;
            user.street = street;
            user.city = city;
            user.state = state;
            user.zip = zip;
            user.addressType = addressType;
            user.number = number;
            user.phoneType = phoneType;
            UserDM userDm = ConvertUserVmToDm(user);
            CreateUser(userDm.personAddressId, userDm.personPhoneId);
            return user;
        }
        public TypeDM CreateType(string type)
        {
            TypeDM typeDm = new TypeDM();
            TypeDAO dao = new TypeDAO();
            typeDm.type = type;
            dao.CreateType(type);
            return typeDm;
        }
        public PhoneDM CreatePhone(string number)
        {
            PhoneDM phone = new PhoneDM();
            PhoneDAO dao = new PhoneDAO();
            phone.number = number;
            dao.CreatePhone(number);
            return phone;
        }
        public AddressDM CreateAddress(string street, string city, string state, string zip)
        {
            AddressDM address = new AddressDM();
            AddressDAO dao = new AddressDAO();
            address.street = street;
            address.city = city;
            address.state = state;
            address.zip = zip;
            dao.CreateAddress(street, city, state, zip);
            return address;
        }
        public PersonPhoneDM CreatePersonPhone(string lastName, string firstName, string email, string number, string type)
        {
            PersonPhoneDAO dao = new PersonPhoneDAO();
            PersonPhoneDM personPhone = new PersonPhoneDM();
            SetPersonPhoneDmPersonId(lastName, firstName, email, personPhone);
            SetPersonPhoneDmPhoneId(number, personPhone);
            SetPersonPhoneDmTypeId(type, personPhone);
            dao.CreatePersonPhone(personPhone.personId, personPhone.phoneId, personPhone.typeId);
            return personPhone;
        }

        private void SetPersonPhoneDmPersonId(string lastName, string firstName, string email, PersonPhoneDM personPhone)
        {
            bool x = DoesPersonExist(SetPersonId(lastName, firstName, email));
            if (x == false)
            {
                CreatePerson(lastName, firstName, email);
                personPhone.personId = SetPersonId(lastName, firstName, email);
            }
            else
            {
                personPhone.personId = SetPersonId(lastName, firstName, email);
            }
        }

        private void SetPersonPhoneDmPhoneId(string number, PersonPhoneDM personPhone)
        {
            bool y = DoesPhoneExist(SetPhoneId(number));
            if (y == false)
            {
                CreatePhone(number);
                personPhone.phoneId = SetPhoneId(number);
            }
            else
            {
                personPhone.phoneId = SetPhoneId(number);
            }
        }

        private void SetPersonPhoneDmTypeId(string type, PersonPhoneDM personPhone)
        {
            bool z = DoesTypeExist(SetTypeId(type));
            if (z == false)
            {
                CreateType(type);
                personPhone.typeId = SetTypeId(type);
            }
            else
            {
                personPhone.typeId = SetTypeId(type);
            }
        }
        public bool DoesPersonExist(int id)
        {
            PersonDAO dao = new PersonDAO();
            return dao.DoesPersonExist(id);
        }
        public bool DoesTypeExist(int id)
        {
            TypeDAO dao = new TypeDAO();
            return dao.DoesTypeExist(id);
        }
        public bool DoesPhoneExist(int id)
        {
            PhoneDAO dao = new PhoneDAO();
            return dao.DoesPhoneExist(id);
        }
        public bool DoesAddressExist(int id)
        {
            AddressDAO dao = new AddressDAO();
            return dao.DoesAddressExist(id);
        }
        public int GetPersonAddressId(int personId, int addressId, int typeId)
        {
            PersonAddressDAO dao = new PersonAddressDAO();
            return dao.GetPersonAddressId(personId, addressId, typeId);
        }
        public int GetPersonPhoneId(int personId, int phoneId, int typeId)
        {
            PersonPhoneDAO dao = new PersonPhoneDAO();
            return dao.GetPersonPhoneId(personId, phoneId, typeId);
        }
        public PersonAddressDM CreatePersonAddress(string lastName, string firstName, string email,
            string street, string city, string state, string zip, string type)
        {
            PersonAddressDAO dao = new PersonAddressDAO();
            PersonAddressDM personAddress = new PersonAddressDM();
            SetPersonAddressDmPersonId(lastName, firstName, email, personAddress);
            SetPersonAddressDmAddressId(street, city, state, zip, personAddress);
            SetPersonAddressDmTypeId(type, personAddress);
            dao.CreatePersonAddress(personAddress.personId, personAddress.addressId, personAddress.typeId);
            return personAddress;
        }
        public void SetPersonAddressDmPersonId(string lastName, string firstName, string email, PersonAddressDM personAddress)
        {
            bool x = DoesPersonExist(SetPersonId(lastName, firstName, email));
            if (x == false)
            {
                CreatePerson(lastName, firstName, email);
                personAddress.personId = SetPersonId(lastName, firstName, email);
            }
            else
            {
                personAddress.personId = SetPersonId(lastName, firstName, email);
            }
        }
        public void SetPersonAddressDmAddressId(string street, string city, string state, string zip, PersonAddressDM personAddress)
        {
            bool y = DoesAddressExist(SetAddressId(street, city, state, zip));
            if (y == false)
            {
                CreateAddress(street, city, state, zip);
                personAddress.addressId = SetAddressId(street, city, state, zip);
            }
            else
            {
                personAddress.addressId = SetAddressId(street, city, state, zip);
            }
        }
        public void SetPersonAddressDmTypeId(string type, PersonAddressDM personAddress)
        {
            bool z = DoesTypeExist(SetTypeId(type));
            if (z == false)
            {
                CreateType(type);
                personAddress.typeId = SetTypeId(type);
            }
            else
            {
                personAddress.typeId = SetTypeId(type);
            }
        }
        public void DeleteMovie(int id)
        {
            MovieDAO dao = new MovieDAO();
            dao.DeleteMovie(id);
        }
        public void DeleteUser(int id)
        {
            UserDAO dao = new UserDAO();
            dao.DeleteUser(id);
        }
        public void DeleteAccount(int id)
        {
            AccountDAO dao = new AccountDAO();
            dao.DeleteAccount(id);
        }
        public List<MovieVM> GetAllMovies()
        {
            List<MovieVM> movieVmList = new List<MovieVM>();
            List<MovieDM> movieDmList = new List<MovieDM>();
            MovieDAO dao = new MovieDAO();
            movieDmList = dao.GetAllMovies();
            foreach (MovieDM movieDm in movieDmList)
            {
                movieVmList.Add(ConvertMovieDmToVm(movieDm));
            }
            return movieVmList;
        }
        public List<UserVM> GetAllUsers()
        {
            List<UserVM> userVmList = new List<UserVM>();
            List<UserDM> userDmList = new List<UserDM>();
            UserDAO dao = new UserDAO();
            userDmList = dao.GetAllUsers();
            foreach (UserDM userDm in userDmList)
            {
                userVmList.Add(ConvertUserDmToVm(userDm));
            }
            return userVmList;
        }
        public List<AccountVM> GetAllAccounts()
        {
            List<AccountVM> accountVmList = new List<AccountVM>();
            List<AccountDM> accountDmList = new List<AccountDM>();
            AccountDAO dao = new AccountDAO();
            accountDmList = dao.GetAllAccounts();
            foreach (AccountDM accountDm in accountDmList)
            {
                accountVmList.Add(ConvertAccountDmToVm(accountDm));
            }
            return accountVmList;
        }
        public void UpdateMovie(int id, string title, DateTime releaseDate, string genre)
        {
            MovieDM movieDm = new MovieDM();
            GenreDAO gdao = new GenreDAO();
            MovieDAO dao = new MovieDAO();
            bool x = gdao.DoesGenreExist(gdao.GetGenreId(genre));
            if (x == false)
            {
                gdao.CreateGenre(genre);
                movieDm.genreId = gdao.GetGenreId(genre);
                dao.UpdateMovieDB(id, title, releaseDate, movieDm.genreId);
            }
            dao.UpdateMovieDB(id, title, releaseDate, gdao.GetGenreId(genre));
        }
        public void UpdateUser(int id, string lastName, string firstName, string email,
            string street, string city, string state, string zip, string addressType,
            string number, string phoneType)
        {
            UserDM user = new UserDM();
            UserDAO dao = new UserDAO();
            PersonAddressDM personAddress = new PersonAddressDM();
            PersonAddressDAO padao = new PersonAddressDAO();
            PersonPhoneDM personPhone = new PersonPhoneDM();
            PersonPhoneDAO ppdao = new PersonPhoneDAO();
            user.personAddressId = SetUserDmPersonAddressId(lastName, firstName, email, 
                street, city, state, zip, addressType, user, padao);
            user.personPhoneId = SetUserDmPersonPhoneId(lastName, firstName, email, 
                number, phoneType, user, ppdao);
            padao.UpdatePersonAddressDB(id, lastName, firstName, email, 
                street, city, state, zip, addressType);
            ppdao.UpdatePersonPhoneDB(id, lastName, firstName, email, number, phoneType);
            dao.UpdateUserDB(id, user.personAddressId, user.personPhoneId);
        }

        public int SetUserDmPersonPhoneId(string lastName, string firstName, string email, 
            string number, string phoneType, UserDM user, PersonPhoneDAO ppdao)
        {
            int a = SetPersonId(lastName, firstName, email);
            int b = SetPhoneId(number);
            int c = SetTypeId(phoneType);
            bool x = ppdao.DoesPersonPhoneExist(GetPersonPhoneId(a,b,c));
            if (x == false)
            {
                ppdao.CreatePersonPhone(a,b,c);
                user.personPhoneId = GetPersonPhoneId(a,b,c);
            }
            else
            {
                user.personPhoneId = GetPersonPhoneId(a,b,c);
            }
            return user.personPhoneId;
        }

        public int SetUserDmPersonAddressId(string lastName, string firstName, string email, 
            string street, string city, string state, string zip, string addressType, 
            UserDM user, PersonAddressDAO padao)
        {
            int a = SetPersonId(lastName, firstName, email);
            int b = SetAddressId(street, city, state, zip);
            int c = SetTypeId(addressType);
            bool x = padao.DoesPersonAddressExist(GetPersonAddressId(a,b,c));
            if (x == false)
            {
                padao.CreatePersonAddress(a,b,c);
                user.personAddressId = GetPersonAddressId(a,b,c);
            }
            else
            {
                user.personAddressId = GetPersonAddressId(a,b,c);
            }
            return user.personAddressId;
        }
    }
}