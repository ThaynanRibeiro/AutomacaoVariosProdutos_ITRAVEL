using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;


namespace Projeto
{
    public class Xp
    {
        public static void XpInvestimentos()
        {
            var dr = ChromeOptionsGeral.ChromeOptionsMain(false);

            {
                try
                {
                    dr.Navigate().GoToUrl("https://wtxpreprod5.travelexplorer.com.br/"); // navega para o Zion
                    Thread.Sleep(2000);

                    dr.FindElement(By.Id("txtLogin")).Click(); // clica no campo da Usuario
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("txtLogin")).SendKeys("suporte@itravel.com.br"); // digita o login do usuario
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_txtPassword")).Click(); // clica no campo da Senha
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_txtPassword")).SendKeys("#ITravel202"); // digita a senha
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_btnLogin")).Click(); // clica no botão "Continuar"
                    Thread.Sleep(1000);

                    try // Verificar se uma mensagem de erro no Login é exibida
                    {
                        IWebElement mensagemErro = dr.FindElement(By.Id("p_lt_ctl00_Login_1_divMsg"));
                        Console.WriteLine("Dados Inválidos!");
                        dr.Quit();

                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Login bem-sucedido!");
                    }

                    dr.FindElement(By.Id("tabFlight")).Click(); // Seleciona pesquisa de voo
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDeparture_txtDescription")).Click(); // Seleciona o campo de Origem
                    Thread.Sleep(2000);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDeparture_txtDescription")).SendKeys("SAO"); // digita a Origem
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("ac_even")).Click(); // seleciona a origem

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtArrival_txtDescription")).Click(); // Seleciona o campo "Destino"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtArrival_txtDescription")).SendKeys("RIO"); // digita o destino
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[3]/ul/li[1]")).Click(); // seleciona o destino
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDepartureDateAero")).Click(); // Abre o calendário de Chekin
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendario
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendario
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[1]/div[2]/table/tbody/tr[3]/td[5]/a")).Click(); // Seleciona a data
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[1]/div[1]/table/tbody/tr[3]/td[7]/a")).Click(); // Seleciona data de volta
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("btnSearchFSX")).Click(); // Clica em "Pesquisar"
                    Thread.Sleep(500);

                    int tentativasAereo = 0;
                    bool elementoPresente = false;

                    while (tentativasAereo < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.Id("Group_0"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativasAereo++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Voos encontrados!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[3]/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[1]/div[2]/div[1]/span[1]/span/input")).Click();
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[3]/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[2]/div[2]/div[1]/span[1]/span/input")).Click();
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("add-flight-cart")).Click(); // Adiciona produto aéreo no carrinho
                    Thread.Sleep(5000);

                    dr.FindElement(By.XPath("//*[@id=\"p_lt_tpMainTag\"]/div[3]/div/div[1]/div[1]/div/ul/li[4]/a/h4/i")).Click(); // Clica no botão para pesquisar Carro
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl03_CSXBuscador_txtPickupLocation_txtCarDestinations_txtDescription")).Click();
                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl03_CSXBuscador_txtPickupLocation_txtCarDestinations_txtDescription")).SendKeys("SAO"); // Digita "Cidade de Retirada"
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[2]/ul/li[1]")).Click(); // Seleciona "Cidade de Retirada"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl03_CSXBuscador_bdpPickupDate")).Click(); // Abre o calendário
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendário
                    Thread.Sleep(500);
                    
                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendário
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/table/tbody/tr[3]/td[5]")).Click(); // Seleciona a "Data de Retirada"
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[1]/table/tbody/tr[3]/td[7]")).Click(); // Seleciona a "Data de Devolução"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("btnSearchCSX")).Click(); // Clica no botão "Pesquisar"
                    Thread.Sleep(500);

                    int tentativasCarro = 0;
                    while (tentativasCarro < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.ClassName("btn-add-cart"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativasCarro++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Carros encontrados!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Carros não encontrados após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    Thread.Sleep(3000);
                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div/div/div[3]/div[1]/div[2]/div[3]/div[1]/div[1]/div[5]/div[1]/span[3]/a")).Click();
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"p_lt_tpMainTag\"]/div[3]/div/div[1]/div[1]/div/ul/li[4]/a")).Click(); // Clica no botão para Pesquisar Hotel
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_HSXBuscador123_ctlDestinationAutoComplete_txtHotelDestinations_txtDescription")).Click(); // Clica no campo "Destino"
                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_HSXBuscador123_ctlDestinationAutoComplete_txtHotelDestinations_txtDescription")).SendKeys("SAO"); // Escreve o "Destino"
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[2]/ul/li[1]")).Click(); // Seleciona o "Destino"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_HSXBuscador123_txtDepartureDate")).Click(); // Abre o calendário de "Chekin"
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendário
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendário
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/table/tbody/tr[3]/td[5]")).Click(); // Seleciona a data de "CheckIn"
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[1]/table/tbody/tr[3]/td[7]")).Click(); // Seleciona a data de "ChekOut"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("btnSearch")).Click(); // Clica no botão "Pesquisar"
                    Thread.Sleep(500);

                    int tentativasHotel = 0;
                    while (tentativasHotel < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.Id("divVerDetalhes"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativasHotel++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Hotéis encontrados!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Hotéis não encontrados após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[2]/div[3]/div[1]/div[3]/div[7]/div[1]/div/div[2]/a/h3")).Click(); // Seleciona o Hotel
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div/div/div/div[4]/div[1]/div[2]/div[4]/div[4]/div/div/div/div[1]/div[4]/div[2]/a")).Click(); // Adiciona hotel no "Carrinho"
                    Thread.Sleep(1500);

                    dr.FindElement(By.XPath("//*[@id=\"p_lt_tpMainTag\"]/div[3]/div/div[2]/div[4]/a[2]")).Click(); // Clica no botão "Avançar"
                    Thread.Sleep(500);

                    int tentativasCarrinho = 0;
                    while (tentativasCarrinho < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.Id("btBuy"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativasCarrinho++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Botão COMPRAR encontrado!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Botão COMPRAR não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }


                    try // Verificar se existe um produto NO SHOW
                    {
                        dr.FindElement(By.ClassName("noshow-message"));
                        Console.WriteLine("Pedido possui item No Show");                        
                        dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[3]/div/div/div[2]/div/div[1]/span[3]/a")).Click();
                        Thread.Sleep(1000);

                        dr.FindElement(By.Id("btRemoveItem")).Click();
                        Thread.Sleep(1000);

                        dr.Navigate().Back();
                        Thread.Sleep(1000);

                        dr.Navigate().Back();
                        Thread.Sleep(4000);

                        int tentativasHotel2 = 0;
                        while (tentativasHotel2 < 120)
                        {
                            try
                            {
                                IWebElement element = dr.FindElement(By.Id("divVerDetalhes"));
                                elementoPresente = true;
                                break;
                            }
                            catch (NoSuchElementException)
                            {
                                Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                                tentativasHotel2++;
                            }
                        }

                        if (elementoPresente)
                        {
                            Console.WriteLine("Hotéis encontrados pela segunda vez!"); // O elemento está presente na página
                        }
                        else
                        {
                            Console.WriteLine("Hotéis não encontrados na segunda tentativa."); // O elemento não foi encontrado após as tentativas máximas
                        }

                        dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[2]/div[3]/div[1]/div[3]/div[7]/div[2]/div/div[2]/a/h3")).Click(); // Seleciona outro Hotel
                        Thread.Sleep(2000);

                        dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div/div/div/div[4]/div[1]/div[2]/div[4]/div[4]/div/div/div/div[1]/div[4]/div[2]/a")).Click(); // Adiciona hotel no "Carrinho"
                        Thread.Sleep(500);

                        dr.FindElement(By.XPath("//*[@id=\"p_lt_tpMainTag\"]/div[3]/div/div[2]/div[4]/a[2]")).Click(); // Clica no botão "Avançar"
                        Thread.Sleep(500);

                        int tentativasCarrinho2 = 0;
                        while (tentativasCarrinho2 < 120)
                        {
                            try
                            {
                                IWebElement element = dr.FindElement(By.Id("btBuy"));
                                elementoPresente = true;
                                break;
                            }
                            catch (NoSuchElementException)
                            {
                                Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                                tentativasCarrinho2++;
                            }
                        }

                        if (elementoPresente)
                        {
                            Console.WriteLine("Realizando nova tentativa de tarifação"); // Tenta tarifar novamente
                        }
                        else
                        {
                            Console.WriteLine("Botão COMPRAR não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                        }

                        dr.FindElement(By.ClassName("noshow-message"));
                        Console.WriteLine("Pedido possui item No Show na segunda tentativa");
                        dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[3]/div/div/div[2]/div/div[1]/span[3]/a")).Click();
                        dr.FindElement(By.Id("btRemoveItem")).Click();
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Pedido não possui item No Show");
                    }
                    try // Verificar se uma mensagem de alteração de valor é exibido em tela
                    {
                        IWebElement mensagemErro = dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[3]/div/div/div/div/div[2]/div[1]"));
                        Console.WriteLine("Mensagem de alteração de valor encontrada! Checkbox marcado");
                        dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[3]/div/div/div/div/div[2]/div[2]/label/input")).Click();

                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Sem alteração de valor!");
                    }

                    dr.FindElement(By.Id("btBuy")).Click(); // Clica no botão "Comprar"
                    Thread.Sleep(500);

                    int tentativasFinalizacao = 0;
                    while (tentativasFinalizacao < 120) // Aguarda carregamento de um elemento
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.ClassName("firstName"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativasFinalizacao++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Elemento encontrado!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    Thread.Sleep(3000);

                    dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[1]/div[1]/div[3]/div/span[3]/input")).Click(); // Seleciona o campo "Nome"
                    dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[1]/div[1]/div[3]/div/span[3]/input")).SendKeys("THAYNAN"); // Insere o nome
                    Thread.Sleep(1500);

                    dr.FindElement(By.ClassName("lastName")).Click(); // Seleciona o campo "Sobrenome"
                    dr.FindElement(By.ClassName("lastName")).SendKeys("RIBEIRO"); // Insere o sobrenome
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("genre")).Click(); // Seleciona campo para inserir o genero
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[1]/div[1]/div[3]/div/span[5]/select/option[2]")).Click(); // Seleciona o sexo M
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("date")).Click(); // Seleciona campo da data de nascimento
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("date")).SendKeys("28092000"); // Insere a data de nascimento
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("document1")).Click(); // Seleciona campo do CPF
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("document1")).SendKeys("513.060.560-80"); // Insere o CPF
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-paxToItem_Car_1\"]/span/span")).Click(); // Abre a lista para selecionar o condutor
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-paxToItem_Car_1-i1\"]")).Click(); // Seleciona o condutor do carro
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-paxToItem_Flight_1\"]/span/span")).Click(); // Abre a lista para selecionar o passageiro do aéreo
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-paxToItem_Flight_1-i0\"]")).Click(); // Seleciona o passageiro do aéreo
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-creditcardSelector_Car_1_0\"]/span/span")).Click(); // Abre lista para selecionar a bandeira do cartão
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-creditcardSelector_Car_1_0-ddw\"]/div/div[2]/label/div")).Click(); // Seleciona a bandeira "Visa"
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-parcelsSelector_Car_1_0\"]/span/span")).Click(); // Abre a lista de parcelamento
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"ddcl-parcelsSelector_Car_1_0-ddw\"]/div/div[2]/label")).Click(); // Seleciona 1 parcela
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardNumber")).Click(); // Seleciona o campo "Número do Cartão"
                    dr.FindElement(By.ClassName("creditcardNumber")).SendKeys("4998181111444444"); // Preenche campo "Número do cartão"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardName")).Click();
                    dr.FindElement(By.ClassName("creditcardName")).SendKeys("THAYNAN RIBEIRO"); // Preenche campo "Nome do titular"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardDocument")).Click();
                    dr.FindElement(By.ClassName("creditcardDocument")).SendKeys("513.060.560-80"); // Preenche campo "CPF" 
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardMonth")).Click();
                    dr.FindElement(By.ClassName("creditcardMonth")).SendKeys("05"); // Preenche campo "Mês Validade"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardYear")).Click();
                    dr.FindElement(By.ClassName("creditcardYear")).SendKeys("2025"); // Preenche campo "Ano Validade"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardSecurityCode")).Click();
                    dr.FindElement(By.ClassName("creditcardSecurityCode")).SendKeys("753"); // Preenche campo "Cód. Segurança"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardZipcode")).Click();
                    dr.FindElement(By.ClassName("creditcardZipcode")).SendKeys("15050-000"); // Preenche campo "Código Postal"
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("creditcardAdressNunber")).Click();
                    dr.FindElement(By.ClassName("creditcardAdressNunber")).SendKeys("123"); // Preenche campo "Número"
                    Thread.Sleep(1000);

                    dr.FindElement(By.XPath("//*[@id=\"chkCreditcardToCopy_Flight_1_1\"]")).Click();
                    Thread.Sleep(1000);

                    dr.FindElement(By.ClassName("acceptterms")).Click(); // Aceita os termos do contrato
                    Thread.Sleep(1000);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // deixa registrado no console o erro que ocorreu
                }

            }
        }
    }
}
