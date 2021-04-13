using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankServer.Models;
using BankServer.Services;
using BankServer.Dtos;
using BankServer.Exceptions;

namespace BankServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<AccountDto> GetAccount()
        {
            return _accountService.GetAll();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public ActionResult<AccountDto> GetAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccountDto accountDto = _accountService.GetById(id);

            if (accountDto == null)
            {
                return NotFound();
            }

            return Ok(accountDto);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutAccount([FromRoute] int id, [FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountDto.AccountId)
            {
                return BadRequest();
            }

            try
            {
                accountDto = _accountService.Save(id, accountDto);
            }
            catch (NotEnoughMoneyException)
            {
                return BadRequest("Not enough money in the account!");
            }

            if (!AccountExists(id))
            {
                return NotFound();
            }

            return Ok(accountDto);
        }

        // PUT: api/Accounts/byNumber/00001234
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("byNumber/{number}")]
        public IActionResult PutAccountByNumber([FromRoute] string number, [FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!number.Equals(accountDto.AccountNumber))
            {
                return BadRequest();
            }

            AccountDto findedByNumberAccountDto;

            try
            {
                findedByNumberAccountDto = _accountService.GetByNumber(accountDto.AccountNumber);
                if (findedByNumberAccountDto != null)
                {
                    findedByNumberAccountDto.AccountMoney = accountDto.AccountMoney;
                    findedByNumberAccountDto = _accountService.Save(findedByNumberAccountDto.AccountId, findedByNumberAccountDto);
                }
                else
                {
                    return NotFound("Account not found!");
                }
            }

            catch (NotEnoughMoneyException)
            {
                return BadRequest("Not enough money in the account!");
            }

            return Ok(findedByNumberAccountDto);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<AccountDto> PostAccount([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccountDto newAccount = _accountService.Save(0, accountDto);

            return CreatedAtAction("GetAccount", new { id = newAccount.AccountId }, newAccount);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public ActionResult<AccountDto> DeleteAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!AccountExists(id))
            {
                return NotFound();
            }

            _accountService.Delete(id);

            return Ok();
        }

        private bool AccountExists(int id)
        {
            return _accountService.EntityExists(id);
        }
    }
}
